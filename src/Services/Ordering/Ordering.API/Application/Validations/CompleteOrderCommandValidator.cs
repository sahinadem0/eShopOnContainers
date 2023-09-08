namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Validations;

public class CompleteOrderCommandValidator : AbstractValidator<CompleteOrderCommand>
{
    public CompleteOrderCommandValidator(ILogger<CompleteOrderCommandValidator> logger)
    {
        RuleFor(order => order.OrderNumber)
              .GreaterThan(0).WithMessage("ordernumber must be greater than 0");

        logger.LogTrace($"INSTANCE CREATED - {GetType().Name}");
    }
}
