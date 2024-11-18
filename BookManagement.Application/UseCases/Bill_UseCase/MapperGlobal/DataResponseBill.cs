using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.MapperGlobal
{
    public class DataResponseBill
    {
        public long Id { get; set; }
        public DataResponseUser DataResponseUser { get; set; }
        public string ShippingMethodName { get; set; }
        public DataResponseAddressUser DataResponseAddressUser { get; set; }
        public string TradingCode { get; set; }
        public string PaymentMethodName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? PayTime { get; set; }
        public double TotalPriceBeforeDiscount { get; set; }
        public string BillStatus { get; set; }
        public string? Note { get; set; }
        public double TotalPriceAfterDiscount { get; set; }
        public double ShippingFee { get; set; }
        public IQueryable<DataResponseBillDetail> DataResponseBillDetails { get; set; }
    }
}
