using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Model;
using WebShoppie.Domain.Services.Exceptions;
using WebShoppie.Persistence.Entities;

namespace WebShoppie.Domain.Services.Mapping
{
    public static class OrderMappingExtensions
    {
        public static OrderModel AsModel(this Order entity)
        {
            return new OrderModel
            {
                CreatedOnUtc = entity.CreatedOnUtc,
                Id = entity.Id,
                CustomerModel = entity.Customer.AsModel(),
                OrderProductModels = entity.OrderProducts.Select(p => p.AsModel()).ToList()
            };
        }

        public static OrderResponseContract AsContract(this OrderModel model)
        {
            return new OrderResponseContract { 
                OrderId = model.Id ?? throw new MappingException(),
                OrderCustomer = model.CustomerModel?.AsOrderCustomerContract() ?? throw new MappingException(),
                OrderDateUtc = model.CreatedOnUtc,
                OrderProducts = model.OrderProductModels.Select(op => op.AsOrderProductContract()).ToList()
            };
        }

        public static OrderOverviewResponseContract AsOverviewContract(this OrderModel model)
        {
            return new OrderOverviewResponseContract()
            {
                OrderId = model.Id ?? throw new InvalidOrderException(),
                CustomerId = model.CustomerModel?.Id ?? throw new InvalidOrderException(),
                OrderDateTimeUtc = model.CreatedOnUtc,
                TotalPrice = model.TotalPrice
            };
        }

        public static Order AsEntity(this OrderModel model)
        {
            return new Order
            {
                CustomerId = model.CustomerModel?.Id ?? throw new MappingException(),
                CreatedOnUtc = model.CreatedOnUtc,
                OrderProducts = model.OrderProductModels.Select(p => p.AsEntity()).ToArray(),
            };
        }

    }
}
