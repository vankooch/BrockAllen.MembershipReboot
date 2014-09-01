using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrockAllen.MembershipReboot.Npgsql
{
    public class PgGroup : Group
    {
        public override IEnumerable<GroupChild> Children
        {
            get { return ChildrenCollection; }
        }

        public virtual ICollection<PgGroupChild> ChildrenCollection { get; set; }

        [Column("key", TypeName = "int4")]
        public virtual int Key { get; set; }

        protected internal override void AddChild(GroupChild child)
        {
            ChildrenCollection.Add(new PgGroupChild { ParentKey = this.Key, ChildGroupID = child.ChildGroupID });
        }

        protected internal override void RemoveChild(GroupChild child)
        {
            ChildrenCollection.Remove((PgGroupChild)child);
        }
    }

    public class PgGroupChild : GroupChild
    {
        [Column("key", TypeName = "int4")]
        public virtual int Key { get; set; }

        [Column("parent_key", TypeName = "int4")]
        public virtual int? ParentKey { get; set; }
    }
}