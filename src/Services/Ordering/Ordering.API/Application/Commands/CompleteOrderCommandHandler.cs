using Duende.IdentityServer.Models;
using Microsoft.eShopOnContainers.Services.Ordering.API.Application.DTOs;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public CompleteOrderCommandHandler(IOrderRepository orderRepository, IOrderingIntegrationEventService orderingIntegrationEventService)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(CompleteOrderCommand completeOrderCommand, CancellationToken cancellationToken)
        {
            var orderToComplete = await _orderRepository.GetAsync(completeOrderCommand.OrderNumber);
            if (orderToComplete == null)
            {
                return false;
            }

            orderToComplete.SetCompletedStatus();            
            return await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
