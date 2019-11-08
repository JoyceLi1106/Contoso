using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Contoso.Data
{
    public interface IRepository <T> where T:class //generic constraints to replace T with different classes; with struct-value type can replace T;
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id (by condition)
        T GetById(int id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where); //Linq expression is a lambda

        int GetCount(Expression<Func<T, bool>> filter = null);
        // Saving the changes to Database
        void SaveChanges();
    }
}
