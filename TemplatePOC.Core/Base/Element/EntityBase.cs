using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Core.Base.Element
{
    public abstract class EntityBase<TId>:IEquatable<EntityBase<TId>>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TId Id { get; set; }

        [Index(IsClustered =true)]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase<TId>;

            if (ReferenceEquals(compareTo, null))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (GetType() != compareTo.GetType())
                return false;

            if (!IsTransient() && !compareTo.IsTransient() && Id.Equals(compareTo.Id))
                return true;

            return false;
        }

        public static bool operator ==(EntityBase<TId> a, EntityBase<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase<TId> a, EntityBase<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public virtual bool IsTransient()
        {
            return Id.Equals(default(TId));
        }

        public bool Equals(EntityBase<TId> other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
