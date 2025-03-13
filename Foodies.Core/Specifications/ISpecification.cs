using Foodies.Core.Entities;
using Foodies.Core.Specifications.Base_ISpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications
{
    public interface ISpecification<T> : IFilterable<T> where T : BaseEntity
    {
        
        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>>? OrderBy { get; set; }
        public Expression<Func<T, object>>? OrderByDesc { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public void AddOrderBy(Expression<Func<T, object>> orderExpression);
        public void AddOrderByDesc(Expression<Func<T, object>> orderExpression);
    }
}
