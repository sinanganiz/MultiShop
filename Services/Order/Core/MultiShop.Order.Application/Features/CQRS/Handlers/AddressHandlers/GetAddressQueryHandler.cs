using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IRepository<Address> _repository;

    public GetAddressQueryHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(a => new GetAddressQueryResult
        {
            AddressId = a.AddressId,
            City = a.City,
            Detail = a.Detail,
            District = a.District,
            UserId = a.UserId
        }).ToList();
    }
}