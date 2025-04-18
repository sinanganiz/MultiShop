using System;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHadler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public UpdateOrderingCommandHadler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var ordering = await _repository.GetByIdAsync(request.OrderingId);
        ordering.OrderDate = request.OrderDate;
        ordering.UserId = request.UserId;
        ordering.TotalPrice = request.TotalPrice;

        await _repository.UpdateAsync(ordering);
    }
}
