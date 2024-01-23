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
    public class OrderDetailService : IOrderDetailService
    {
        protected  readonly IOrderDetailRepo _orderDetailRepo; 
        protected readonly IMapper _mapper; 
        public OrderDetailService(IOrderDetailRepo orderDetailRepo, IMapper mapper)
        {
            _orderDetailRepo = orderDetailRepo; 
            _mapper = mapper; 
        }
        public async Task<IEnumerable<OrderDetailReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
           var orderDetailList = await _orderDetailRepo.GetAllAsync(getAllOptions);
           return _mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailReadDto>>(orderDetailList); 
        }

        public Task<OrderDetailReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}