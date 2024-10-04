using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Commons.Base
{
    public interface IEntity
    {
        object[] GetKeys();
    }
    public interface IEntity<TKey> : IEntity, IHasKey<TKey>
    {
    }
}
