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
    public class TemplateDescription:ValueObjectBase<TemplateDescription>
    {
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { get; set; }

        public enLobbyStatus Status { get; set; }

        public enLobbyType Type { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string PreviewUrl { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string Credential { get; set; }

        protected override bool EqualsCore(TemplateDescription other)
        {
            return this.Name == other.Name &&
                this.Description == other.Description &&
                this.Status == other.Status &&
                this.Type == other.Type &&
                this.PreviewUrl == other.PreviewUrl;
        }

        protected override int GetHashCodeCore()
        {
            unchecked {
                int hashCode = 0;
                hashCode = this.Name.GetHashCode() +
                    this.Description.GetHashCode() +
                    this.Status.GetHashCode() +
                    this.Type.GetHashCode() +
                    this.PreviewUrl.GetHashCode();

                return hashCode;
            }
        }
    }
}
