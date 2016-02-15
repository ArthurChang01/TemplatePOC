using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.Models.Template.POCO
{
    [Table("LobbyGameGroup")]
    public class LobbyGameGroup
    {
        public LobbyGameGroup() {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName ="nvarchar")]
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

        [ForeignKey("Lobby")]
        public Guid LobbyId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual Lobby Lobby { get; set; }
    }
}