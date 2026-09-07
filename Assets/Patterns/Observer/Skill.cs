using System.Collections.Generic;

namespace Patterns.Behaviour.Observer
{
    public class Skill : Subject
    {
        private readonly List<Observer> observers;

        public int Charges { get; private set; }
        public bool IsReady => Charges > 0;

        public Skill()
        {
            Charges = 3;
            observers = new List<Observer>();
        }

        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
            observer.Updated(this);
        }

        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Updated(this);
            }
        }

        public void Use()
        {
            if (Charges <= 0)
            {
                return;
            }

            Charges -= 1;
            Notify();
        }
    }
}
