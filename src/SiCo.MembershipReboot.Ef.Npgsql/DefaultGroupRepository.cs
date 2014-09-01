using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Npgsql;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DefaultGroupRepository
        : DbContextGroupRepository<DefaultMembershipRebootDatabase, PgGroup>,
          IGroupRepository
    {
        public DefaultGroupRepository()
        {
        }

        public DefaultGroupRepository(string name)
            : base(new DefaultMembershipRebootDatabase(name))
        {
        }

        public DefaultGroupRepository(string name, string schemaName)
            : base(new DefaultMembershipRebootDatabase(name, schemaName))
        {
        }

        private IGroupRepository<PgGroup> This { get { return (IGroupRepository<PgGroup>)this; } }

        public void Add(Group item)
        {
            This.Add((PgGroup)item);
        }

        public new Group Create()
        {
            return This.Create();
        }

        public new System.Collections.Generic.IEnumerable<Group> GetByChildID(System.Guid childGroupID)
        {
            return This.GetByChildID(childGroupID);
        }

        public new Group GetByID(System.Guid id)
        {
            return This.GetByID(id);
        }

        public new System.Collections.Generic.IEnumerable<Group> GetByIDs(System.Guid[] ids)
        {
            return This.GetByIDs(ids);
        }

        public new Group GetByName(string tenant, string name)
        {
            return This.GetByName(tenant, name);
        }

        public void Remove(Group item)
        {
            This.Remove((PgGroup)item);
        }

        public void Update(Group item)
        {
            This.Update((PgGroup)item);
        }
    }
}