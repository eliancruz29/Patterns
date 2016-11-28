using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Example
{
    class Counter : ISubject
    {
        private static readonly Counter instance = new Counter();
        private static object syncRoot = new Object();
        private List<IObserver> observers;
        private int count;

        private Counter()
        {
            observers = new List<IObserver>();
            count = 0;
        }

        public static Counter Instance
        {
            get
            {
                return instance;
            }
        }

        public void UpdateCount(int count)
        {
            lock (syncRoot)
            {
                this.count = count;
                NotifyObservers(count);
            }
        }

        public void Increment()
        {
            lock (syncRoot)
            {
                count++;
                NotifyObservers(count);
            }
        }

        public void Decrement()
        {
            lock (syncRoot)
            {
                if (count > 0)
                {
                    count--;
                    NotifyObservers(count);
                }
            }
        }

        public void NotifyObservers(int count)
        {
            lock (syncRoot)
            {
                foreach (IObserver ob in observers)
                {
                    ob.Update(count);
                }
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            lock (syncRoot)
            {
                if (!observers.Contains(observer))
                    observers.Add(observer);
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            lock (syncRoot)
            {
                observers.Remove(observer);
            }
        }
    }
}
