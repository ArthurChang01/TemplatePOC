using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Core.Base.Interface
{
    public interface IEvent : IMessage
    {
        Guid Id { get; }
    }
}
