using Foodies.Core;
using Foodies.Core.Entities;
using Foodies.Core.IRepositories;
using Foodies.Core.Specifications;
using Foodies.Core.Specifications.Base_ISpecifications;
using Foodies.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //if (typeof(T) == typeof(Food))
            //    return (IEnumerable<T>) await _dbContext.Foods.Include(F => F.Category).Include(F => F.Vendor).ToListAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            //if (typeof(T) == typeof(Food))
            //    return await _dbContext.Foods.Where(F => F.Id == id).Include(F => F.Category).Include(F => F.Vendor).FirstOrDefaultAsync() as T;
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> specs)
        {
            //    return await _dbContext.Foods.Where(F => F.CategoryId == categoryId && F => F.VendorId == vendorId).Include(F => F.Category).Include(F => F.Vendor).Skip(10).Take(10).ToListAsync() as T;
            return await ApplySpecs(specs).ToListAsync();
        }

        public async Task<T?> GetWithSpecsAsync(ISpecification<T> specs)
        {
            return await ApplySpecs(specs).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(IFilterable<T> specs)
        {
            //    return await _dbContext.Foods.Where(F => F.CategoryId == categoryId && F => F.VendorId == vendorId).CountAsync();
            return await ApplySpecs(specs).CountAsync();
        }


        private IQueryable<T> ApplySpecs(ISpecification<T> specs)
        {
            return SpecsEvaluator<T>.CreateQuery(_dbContext.Set<T>(), specs);
        }

        private IQueryable<T> ApplySpecs(IFilterable<T> filterSpecs)
        {
            return SpecsEvaluator<T>.ApplyFilteration(_dbContext.Set<T>(), filterSpecs);
        }

        public async Task AddAsync(T entity)
            => await _dbContext.Set<T>().AddAsync(entity);

        public void Update(T entity)
            => _dbContext.Update(entity);

        public void Delete(T entity)
            => _dbContext.Remove(entity);
    }
}
