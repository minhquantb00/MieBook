using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories
{
    public interface ISpecificationFactory
    {
        ISpecification<T> Create<T>();
    }
}
