namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Validations;

public class CompleteOrderCommandValidator : AbstractValidator<CompleteOrderCommand>
{
    public CompleteOrderCommandValidator(ILogger<CompleteOrderCommandValidator> logger)
    {
        RuleFor(order => order.OrderNumber).NotEmpty().NotNull().WithMessage("Cannot be empty or null orderid");

        logger.LogTrace($"INSTANCE CREATED - {GetType().Name}");
    }
}
