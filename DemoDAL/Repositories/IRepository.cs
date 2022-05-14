using System.Collections.Generic;

namespace DemoDAL.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetItems();
        T Insert(T model);
    }



}
