using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public interface IStorage<T>
    {
        Task<T> GetAsync();
        Task SetAsync(T obj);
    }
}