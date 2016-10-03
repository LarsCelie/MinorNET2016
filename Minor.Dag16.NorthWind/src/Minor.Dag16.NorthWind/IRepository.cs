using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag16.NorthWind
{
    interface IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
