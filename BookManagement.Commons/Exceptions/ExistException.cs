using BookManagement.Commons.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Commons.Exceptions
{
    public class ExistException : Exception
    {
        public string Name { get; private set; }

        public ExistException(string name)
        {
            Name = name;
        }
        public override string Message => string.Format(Constant.ExceptionMessage.ALREADY_EXIST, Name);
    }
}
