using Foodies.Core.Entities;
using Foodies.Core.Entities.Order_Aggregate;
using Foodies.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<T> Repo<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
