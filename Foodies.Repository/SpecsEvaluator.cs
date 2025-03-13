using Foodies.Core;
using Foodies.Core.Entities;
using Foodies.Core.Specifications;
using Foodies.Core.Specifications.Base_ISpecifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Repository
{
    internal static class SpecsEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> CreateQuery(IQueryable<T> dbSet, ISpecification<T> specs)
        {
            var query = ApplyFilteration(dbSet, specs);

            if (specs.OrderBy is not null)
                query = query.OrderBy(specs.OrderBy);  
            else if (specs.OrderByDesc is not null)
                query = query.OrderByDescending(specs.OrderByDesc);  // _dbContext.Foods.Where(F => F.VendorId == 2 && F => F.CategoryId == 103).OrderyByDesc(F => F.UnitPrice)

            if (specs.IsPaginationEnabled)
                query = query.Skip(specs.Skip).Take(specs.Take);  // _dbContext.Foods.Where(F => F.VendorId == 2 && F => F.CategoryId == 103).OrderyByDesc(F => F.UnitPrice).Skip(4).Take(2)

            query = specs.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        public static IQueryable<T> ApplyFilteration(IQueryable<T> dbSet, IFilterable<T> filterSpec)
        {
            var query = dbSet;  // _dbContext.Foods

            if (filterSpec.Criteria is not null)
                query = query.Where(filterSpec.Criteria);

            return query;
        }
    }
}
