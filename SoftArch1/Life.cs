using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Life:IObservable
    {
        private static Life instance;
        private List<IObserver> observers;
        public int HoursPassed { private set; get; }
        private Life() {
            observers = new List<IObserver>();
            HoursPassed = 0;
        }
        public static Life getInstance()
        {
            if (instance == null)
            {
                return instance = new Life();
            }
            return instance;
        }
        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers(int hours)
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(hours);
            }
        }
        public void PassTime(int hours)
        {
            HoursPassed += hours;
            NotifyObservers(hours);
        }
    }
}
