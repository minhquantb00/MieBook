using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEventById
{
    public class GetDiscountEventByIdUseCase : IUseCaseGetById<long, GetDiscountEventByIdUseCaseOutput>
    {
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly DiscountEventConverter _discountEventConverter;
        public GetDiscountEventByIdUseCase(IRepository<DiscountEvent> discountEventRepository, DiscountEventConverter discountEventConverter)
        {
            _discountEventRepository = discountEventRepository;
            _discountEventConverter = discountEventConverter;
        }

        public async Task<GetDiscountEventByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetDiscountEventByIdUseCaseOutput result = new GetDiscountEventByIdUseCaseOutput
            {
                Succeeded = false
            };

            var query = await _discountEventRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseDiscountEvent = _discountEventConverter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
