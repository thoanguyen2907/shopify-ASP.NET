using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shopify.src.Abstraction;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Service.Impl
{
    public class OrderService : IOrderService
    {
        protected readonly IOrderRepo _orderRepo;
        protected readonly IMapper _mapper;
        public OrderService(IOrderRepo repo, IMapper mapper)
        {
            _orderRepo = repo;
            _mapper = mapper;
        }
        public async Task<OrderReadDto> CreateOneAsync(Guid UserId, OrderCreateDto createDto)
        {
            Console.WriteLine($"this is user id in order service {UserId}");
            var order = _mapper.Map<OrderCreateDto, Order>(createDto);
            order.UserId = UserId;
            await _orderRepo.CreateOneAsync(order);
            return _mapper.Map<Order, OrderReadDto>(order);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order is null)
            {
                return false;
            }
            return await _orderRepo.DeleteOneAsync(order);

        }
        public async Task<IEnumerable<OrderReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
            var orderList = await _orderRepo.GetAllAsync(getAllOptions);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderReadDto>>(orderList);
        }

        public async Task<OrderReadDto> GetByIdAsync(Guid id)
        {
            var foundOrder = await _orderRepo.GetByIdAsync(id);
            if (foundOrder is null)
            {
                throw CustomException.NotFound("Not find order with ${id}");
            }
            return _mapper.Map<Order, OrderReadDto>(foundOrder);
        }
    }
}