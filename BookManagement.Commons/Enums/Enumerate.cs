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
    }
}
