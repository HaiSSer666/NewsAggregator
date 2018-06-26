using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    using IObserver = Object;
    class ObservableStorage<T> : SyncStorage<T>, IObservable<T>
    {
        private List<RegisteredObserver<T>> registeredObserversList = new List<RegisteredObserver<T>>();

        public void AddObserver(IObserver observer, OnUpdateStorage<T> onUpdate)
        {
            RegisteredObserver<T> registeredObserver = new RegisteredObserver<T>(observer, onUpdate);
            registeredObserversList.Add(registeredObserver);
        }

        public void RemoveObserver(IObserver observer)
        {
            registeredObserversList.RemoveAll(registeredObserver => registeredObserver.observer == observer);
        }

        public void NotifyObservers(T updatedObject)
        {
            foreach (RegisteredObserver<T> observer in registeredObserversList)
            {
                observer.onUpdateStorage(updatedObject);
            }
        }
    }
}