using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    /* kullandığım T generic ifadesini sınırlandımak istedim 
     * herhangi bir ifade yazılamasın örnek olarak int gibi bool gibi bir sınıf olsun
     * istedim.*/
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
