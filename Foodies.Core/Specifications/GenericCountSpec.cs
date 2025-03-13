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
    public class GenericCountSpec<T> : IFilterable<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public GenericCountSpec(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
    }
}
