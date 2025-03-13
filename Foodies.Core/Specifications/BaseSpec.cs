using Foodies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications
{
    public class BaseSpecs<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>>? OrderBy { get; set; }
        public Expression<Func<T, object>>? OrderByDesc { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; } = false;

        public BaseSpecs()
        {
            
        }

        public BaseSpecs(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddOrderBy(Expression<Func<T, object>> orderExpression)
        {
            OrderBy = orderExpression;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> orderExpression)
        {
            OrderByDesc = orderExpression;
        }

        public void ApplyPagination(int pageSize, int pageIndex)
        {
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
            IsPaginationEnabled = true;
        }
    }
}
