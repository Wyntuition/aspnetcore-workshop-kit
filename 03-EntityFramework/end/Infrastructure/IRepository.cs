using System.Collections.Generic;

namespace ConsoleApplication.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Find(string key);
        T Remove(string key);
        void Update(T item);
    }
}