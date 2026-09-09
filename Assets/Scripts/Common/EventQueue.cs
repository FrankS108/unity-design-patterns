using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class EventQueue : MonoBehaviour
    {
        public static EventQueue Instance { get; private set; }

        private Queue<EventData> currentEvents;
        private Queue<EventData> nextEvents;

        private Dictionary<EventIds, List<EventObserver>> observers;

        private void Awake()
        {
            Instance = this;

            currentEvents = new Queue<EventData>();
            nextEvents = new Queue<EventData>();
            observers = new Dictionary<EventIds, List<EventObserver>>();
        }

        public void Subscribe(EventIds eventId, EventObserver eventObserver)
        {
            if (!observers.TryGetValue(eventId, out var eventObservers))
            {
                eventObservers = new List<EventObserver>();
            }

            eventObservers.Add(eventObserver);
            observers[eventId] = eventObservers;
        }

        public void Unsubscribe(EventIds eventId, EventObserver eventObserver)
        {
            observers[eventId].Remove(eventObserver);
        }

        public void EnqueueEvent(EventData eventData)
        {
            nextEvents.Enqueue(eventData);
            Debug.Log($"Enqueued event {eventData.EventId} on frame {Time.frameCount}");
        }

        private void LateUpdate()
        {
            ProcessEvents();
        }

        private void ProcessEvents()
        {
            var tempCurrentEvents = currentEvents;
            currentEvents = nextEvents;
            nextEvents = tempCurrentEvents;

            foreach (var currentEvent in currentEvents)
            {
                ProcessEvent(currentEvent);
            }

            currentEvents.Clear();
        }

        private void ProcessEvent(EventData eventData)
        {
            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");

            if (observers.TryGetValue(eventData.EventId, out var eventObservers))
            {
                foreach (var eventObserver in eventObservers)
                {
                    eventObserver.Process(eventData);
                }
            }
        }
    }
}
