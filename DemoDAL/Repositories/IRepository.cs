using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoDAL.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetItems();
        Task<T> InsertAsync(T model);
        Task<T>  UpdateAsync(T model);
    }



}
