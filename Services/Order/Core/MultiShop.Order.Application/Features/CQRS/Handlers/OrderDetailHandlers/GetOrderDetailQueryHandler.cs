using System;
using System.Reflection.Metadata;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(od => new GetOrderDetailQueryResult
        {
            OrderDetailId = od.OrderDetailId,
            ProductAmount = od.ProductAmount,
            OrderingId = od.OrderingId,
            ProductId = od.ProductId,
            ProductName = od.ProductName,
            ProductPrice = od.ProductPrice,
            ProductTotalPrice = od.ProductTotalPrice
        }).ToList();
    }
}
