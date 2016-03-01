using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Core.SubDomain.LobbyDomain.Interface
{
    public interface ILobbyUnitOfWork:IDisposable
    {
        ILobbyRepository LobbyRepository { get; }

        void Save();
    }
}
