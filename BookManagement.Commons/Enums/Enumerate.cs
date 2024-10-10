using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagement.Commons.Enums
{
    public class Enumerate
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Gender
        {
            KhongXacDinh = 0,
            Nam = 1,
            Nu = 2
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum VoucherStatus
        {
            ChuaApDung = 0,
            DangSuDung = 1,
            HetHan = 2
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum BookStatus
        {
            HetHang = 0,
            DangBan = 1
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ShippingMethodStatus
        {
            ChuaApDung = 0,
            DangApDung = 1
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum BillStatus
        {
            ChuaThanhToan = 0,
            DaThanhToan = 1,
            DaHuy = 2
        }
    }
}
