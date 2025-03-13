﻿using Foodies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Base_ISpecifications
{
    public interface IFilterable <T> where T: BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
    }
}
