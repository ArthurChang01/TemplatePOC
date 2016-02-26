using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Service.Base;

namespace TemplatePOC.Service.SubDomain.AuthenticationDomain.DataAccess
{
    public class AuthenticationRepository:Repository<Guid,AuthenticationContext>
    {
        public AuthenticationRepository()
            : base(new AuthenticationContext())
        { }


    }
}
