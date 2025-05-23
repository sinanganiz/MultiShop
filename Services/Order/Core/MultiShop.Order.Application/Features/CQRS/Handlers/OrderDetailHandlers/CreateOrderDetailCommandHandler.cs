using System;
using System.Reflection.Metadata;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderDetailCommand command)
    {
        await _repository.CreateAsync(new OrderDetail
        {
            OrderingId = command.OrderingId,
            ProductAmount = command.ProductAmount,
            ProductId = command.ProductId,
            ProductPrice = command.ProductPrice,
            ProductName = command.ProductName,
            ProductTotalPrice = command.ProductTotalPrice
        });
    }
}
