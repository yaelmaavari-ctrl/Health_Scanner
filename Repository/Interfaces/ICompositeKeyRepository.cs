using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICompositeKeyRepository<T>
    {

            Task<List<T>> GetAll();
            Task<T> GetById(int id1, int id2);
            Task<T> AddItem(T item);
            Task<T> UpdateItem(int id1, int id2, T item);
            Task DeleteItem(int id1, int id2);

    }
}
