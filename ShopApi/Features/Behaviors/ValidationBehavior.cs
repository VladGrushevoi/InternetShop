using FluentValidation;
using FluentValidation.Results;

namespace ShopApi.Features.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger, IEnumerable<IValidator<TRequest>> validators)
    {
        _logger = logger;
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            string typeName = typeof(TRequest).ToString();
            
            _logger.LogInformation("Validating command type {TypeName}", typeName);

            ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
            ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            List<ValidationFailure> failures = validationResults.SelectMany(result => result.Errors).Where(e => e != null).ToList();
            if (failures.Any())
            {
                _logger.LogInformation(
                    "Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", 
                    typeName, request, failures
                    );
                
                throw new Exception(
                    $"Command Validation Errors for type {typeof(TRequest).Name}",
                    new ValidationException("Validation exception", failures));
            }
        }

        return await next();
    }
}