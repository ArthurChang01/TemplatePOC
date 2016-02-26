using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Core.Base.Interface
{
    public interface IEventHandler
    {
        string Name { get; }
    }

    public interface IEventHandler<TEvent> : IEventHandler,IMessageHandler<TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}
