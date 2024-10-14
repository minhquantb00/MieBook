using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.ResponseModels
{
    public class DataResponseMessage
    {
        public static string GetEmailSuccessMessage(string emailAddress) => $"Email đã được gửi đến: {emailAddress}";
    }
}
