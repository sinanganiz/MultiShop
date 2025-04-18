using System;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var orderDetail = await _repository.GetByIdAsync(query.Id);

        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderingId = orderDetail.OrderingId,
            ProductAmount = orderDetail.ProductAmount,
            ProductId = orderDetail.ProductId,
            ProductName = orderDetail.ProductName,
            ProductPrice = orderDetail.ProductPrice,
            ProductTotalPrice = orderDetail.ProductTotalPrice
        };
    }
}
