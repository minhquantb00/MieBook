using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Bill_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.GetBillById
{
    public class GetBillByIdUseCase : IUseCaseGetById<long, GetBillByIdUseCaseOutput>
    {
        private readonly IRepository<Bill> _billRepository;
        private readonly BillConverter _billConverter;
        public GetBillByIdUseCase(IRepository<Bill> billRepository, BillConverter billConverter)
        {
            _billRepository = billRepository;
            _billConverter = billConverter;
        }
        public async Task<GetBillByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetBillByIdUseCaseOutput result = new GetBillByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _billRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseBill = _billConverter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
