using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models.Interfaz
{
    public interface IRepositoryApi<T>
    {
        IEnumerable<T> getAll();
        T get(int id = 0);
        T create(T value);
        T update(int id, T value);
        T delete(int id);
        void setResource(string rosource);
    }
}
