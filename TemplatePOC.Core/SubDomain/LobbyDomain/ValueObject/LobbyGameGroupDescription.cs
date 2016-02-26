using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Base;

namespace TemplatePOC.Core.SubDomain.LobbyDomain.ValueObject
{
    public class LobbyGameGroupDescription : ValueObjectBase<LobbyGameGroupDescription>
    {
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(10)]
        public string ShortName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Path { get; set; }

        protected override bool EqualsCore(LobbyGameGroupDescription other)
        {
            return this.Name == other.Name &&
                this.ShortName == other.ShortName &&
                this.Code == other.Code &&
                this.Description == other.Description &&
                this.Path == other.Path;
        }

        protected override int GetHashCodeCore()
        {
            unchecked {
                int hashCode = 0;
                hashCode = this.Name.GetHashCode() +
                    this.ShortName.GetHashCode() +
                    this.Code.GetHashCode() +
                    this.Description.GetHashCode() +
                    this.Path.GetHashCode();

                return hashCode;
            }
        }
    }
}
