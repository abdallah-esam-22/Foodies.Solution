using Foodies.Core.Entities;
using Foodies.Core.Specifications;
using Foodies.Core.Specifications.Base_ISpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T?> GetWithSpecsAsync(ISpecification<T> specs);

        Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> specs);

        Task<int> GetCountAsync(IFilterable<T> specs);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
