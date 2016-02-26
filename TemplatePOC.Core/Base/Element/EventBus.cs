using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Base.Interface;

namespace TemplatePOC.Core.Base.Element
{
    class EventPassenger
    {
        public string Name { get; private set; }

        public IEventHandler Handler { get; private set; }

        public Type EventType { get; private set; }

        public EventPassenger(IEventHandler handler, Type eventType)
        {
            this.Name = handler.Name;
            this.Handler = handler;
            this.EventType = eventType;
        }

        public override bool Equals(object obj)
        {
            return Name.Equals((obj as EventPassenger).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public class EventBus
    {
        private static List<EventPassenger> _actions;

        public static void Register<Tevent>(IEventHandler @eventHandler) where Tevent : Event
        {
            _actions = _actions ?? new List<EventPassenger>();

            EventPassenger passenger = new EventPassenger(@eventHandler as IEventHandler, typeof(Tevent));
            if (!_actions.Contains(passenger))
                _actions.Add(passenger);
        }

        public static async Task Raise<T>(T @event) where T : IEvent
        {
            Type targetType = typeof(T);
            _actions.Where(o => o.EventType == targetType)
                          .ToList()
                          .ForEach(async o =>
                              await (o.Handler as IEventHandler<T>).Handle(@event));

        }
    }
}
