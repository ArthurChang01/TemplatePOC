using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.SubDomain.LobbyDomain.Interface;

namespace TemplatePOC.Service.SubDomain.LobbyDomain.DataAccess
{
    public class LobbyUnitOfWork : ILobbyUnitOfWork
    {
        private LobbyContext context = new LobbyContext();
        private ILobbyRepository repository;

        public ILobbyRepository LobbyRepository
        {
            get
            {
                return this.repository ?? (new LobbyRepository(this.context));
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
