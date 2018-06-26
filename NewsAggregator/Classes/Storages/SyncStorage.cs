using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    class SyncStorage<T> : IStorage<T>
    {
        public async Task<T> GetAsync()
        {
            return await Task.Run(() =>
            {
                return GetSync();
            });
        }

        public async Task SetAsync(T obj)
        {
            await Task.Run(() =>
            {
                SetSync(obj);
            });
        }

        protected virtual T GetSync()
        {
            throw new NotImplementedException();
        }

        protected virtual void SetSync(T obj)
        {
            throw new NotImplementedException();
        }
    }
}