using BookManagement.Commons.Base;
using BookManagement.Domain.Repositories;
using BookManagement.Domain.UnitOfWorks;
using BookManagement.Infrastructure.DataAccess;
using BookManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> _repositories;
        private readonly IServiceProvider _serviceProvider;
        private readonly IDbContext _dbContext;

        public UnitOfWork(AppDbContext context,
            IServiceProvider serviceProvider,
            IDbContext dbContext)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _repositories = new Dictionary<Type, object>();
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> Repository<T>() where T : BaseEntity<long>
        {
            // Nếu đã có repository cho kiểu T, trả về repository đó
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }

            // Nếu chưa có, tạo mới một repository cho kiểu T
            var repository = new Repository<T>(_context, _dbContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
