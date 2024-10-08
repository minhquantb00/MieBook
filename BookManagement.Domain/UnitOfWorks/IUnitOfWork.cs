using BookManagement.Commons.Base;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<T> Repository<T>() where T : BaseEntity<long>;

        void SaveChanges();

        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
    }
}
