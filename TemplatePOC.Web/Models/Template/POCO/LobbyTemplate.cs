using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.ValueObject;

namespace TemplatePOC.Web.Models.Template.POCO
{
    [Table("LobbyTemplate")]
    public class LobbyTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName ="nvarchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string TemplateName { get; set; }

        public enLobbyType Type { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { get; set; }

        public enLobbyStatus Status { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Credential { get; set; }

        public virtual ICollection<GameGroup> GameGroups { get; set; }
    }
}