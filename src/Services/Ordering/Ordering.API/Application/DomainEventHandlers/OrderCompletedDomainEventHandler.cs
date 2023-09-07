using Ordering.Domain.Events;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.DomainEventHandlers
{
    public class OrderCompletedDomainEventHandler : INotificationHandler<OrderCompletedDomainEvent>
    {
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;
        public OrderCompletedDomainEventHandler(IOrderingIntegrationEventService orderingIntegrationEventService)
        {
            _orderingIntegrationEventService = orderingIntegrationEventService;
        }
        public async Task Handle(OrderCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var orderCompletedIntegrationEvent = new OrderCompletedIntegrationEvent(notification.Order.Id);
            await _orderingIntegrationEventService.AddAndSaveEventAsync(orderCompletedIntegrationEvent);
        }
    }
}
