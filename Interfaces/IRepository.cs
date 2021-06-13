using System.Collections.Generic;

namespace poo_exemple.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T getById(int id);
        void save(T entity);
        void update(int id, T entity);
        void delete(int id);
        int nextId();
    }
}