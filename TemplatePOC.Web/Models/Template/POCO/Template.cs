using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.ValueObject;

namespace TemplatePOC.Web.Models.Template.POCO
{
    [Table("Template")]
    public class Template
    {
        public Template() {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.Status = enLobbyStatus.Activate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName ="nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        public enLobbyType Type { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { get; set; }

        public enLobbyStatus Status { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string PreviewUrl { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string Credential { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual List<TemplateGameGroup> GameGroups { get; set; }

        public virtual List<Lobby> Lobbies { get; set; }
    }
}