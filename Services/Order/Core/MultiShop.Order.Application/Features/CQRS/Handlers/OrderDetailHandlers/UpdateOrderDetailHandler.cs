using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var orderDetail = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailID);
            orderDetail.OrderingID = updateOrderDetailCommand.OrderingID;
            orderDetail.ProductID = updateOrderDetailCommand.ProductID;
            orderDetail.ProductPrice = updateOrderDetailCommand.ProductPrice;
            orderDetail.ProductName = updateOrderDetailCommand.ProductName;
            orderDetail.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            orderDetail.ProductAmount = updateOrderDetailCommand.ProductAmount;
            await _repository.UpdateAsync(orderDetail);
        }
    }
}
