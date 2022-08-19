using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Repositories
{
    public class FindServiceHnRepositoryBase<TEntity> : RepositoryBase<TEntity, FindServiceHnContext> 
        where TEntity : class
    {
        public FindServiceHnRepositoryBase(FindServiceHnContext context) : base(context)
        {
        }
    }
}
