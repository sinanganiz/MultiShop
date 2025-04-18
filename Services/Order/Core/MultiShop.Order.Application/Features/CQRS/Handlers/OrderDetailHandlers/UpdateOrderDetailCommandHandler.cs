using System;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var orderDetail = await _repository.GetByIdAsync(command.OrderDetailId);

        orderDetail.OrderingId = command.OrderingId;
        orderDetail.ProductAmount = command.ProductAmount;
        orderDetail.ProductId = command.ProductId;
        orderDetail.ProductPrice = command.ProductPrice;
        orderDetail.ProductName = command.ProductName;
        orderDetail.ProductTotalPrice = command.ProductTotalPrice;

        await _repository.UpdateAsync(orderDetail);
    }
}
