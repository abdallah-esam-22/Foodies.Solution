using Foodies.Core;
using Foodies.Core.Entities;
using Foodies.Core.Entities.Order_Aggregate;
using Foodies.Core.IRepositories;
using Foodies.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private Hashtable Repos = new Hashtable();


        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await _dbContext.DisposeAsync();

        public IGenericRepository<T> Repo<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;

            if (!Repos.ContainsKey(key))
            {
                var repo = new GenericRepository<T>(_dbContext);
                Repos.Add(key, repo);
            }

            return Repos[key] as IGenericRepository<T>;
        }
    }
}
