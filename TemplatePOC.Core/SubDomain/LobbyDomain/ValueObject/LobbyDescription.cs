using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Base;
using TemplatePOC.Core.SubDomain.LobbyDomain.Enums;

namespace TemplatePOC.Core.SubDomain.LobbyDomain.ValueObject
{
    public class LobbyDescription:ValueObjectBase<LobbyDescription>
    {
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { get; set; }

        public enLobbyType Type { get; set; }

        public enLobbyStatus Status { get; set; }

        public string CSS { get; set; }

        protected override bool EqualsCore(LobbyDescription other)
        {
            return this.Name == other.Name &&
                this.Description == other.Description &&
                this.Type == other.Type &&
                this.Status == other.Status &&
                this.CSS == other.CSS;
        }

        protected override int GetHashCodeCore()
        {
            unchecked {
                int hashCode = 0;
                hashCode = this.Name.GetHashCode() +
                    this.Description.GetHashCode() +
                    this.Type.GetHashCode() +
                    this.Status.GetHashCode() +
                    this.CSS.GetHashCode();
                return hashCode;
            }
        }
    }
}
