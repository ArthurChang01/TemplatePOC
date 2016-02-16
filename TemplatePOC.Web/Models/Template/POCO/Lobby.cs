using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.ValueObject;

namespace TemplatePOC.Web.Models.Template.POCO
{
    [Table("Lobby")]
    public class Lobby
    {
        public Lobby() {
            this.Status= enLobbyStatus.Activate;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { get; set; }

        public enLobbyType Type { get; set; }

        public enLobbyStatus Status { get; set; }

        [ForeignKey("Template")]
        public Guid TemplateId { get; set; }

        [Column(TypeName = "varchar")]
        public string CSS { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string Credential { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual List<LobbyGameGroup> GameGroups { get; set; }

        public virtual Template Template { get; set; }
    }
}