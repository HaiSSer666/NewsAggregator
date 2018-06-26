using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    using IObserver = Object;
    delegate void OnUpdateStorage<UT>(UT updatedValue);

    struct RegisteredObserver<T>
    {
        public IObserver observer;
        public OnUpdateStorage<T> onUpdateStorage;

        public RegisteredObserver(IObserver observer, OnUpdateStorage<T> onUpdateUserStorage)
        {
            this.observer = observer;
            this.onUpdateStorage = onUpdateUserStorage;
        }
    }

    interface IObservable <T>
    {
        void AddObserver(IObserver observer, OnUpdateStorage<T> onUpdate);
        void RemoveObserver(IObserver observer);
    }
}