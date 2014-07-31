using BrockAllen.MembershipReboot;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DefaultGroupRepository
        : DbContextGroupRepository<DefaultMembershipRebootDatabase, RelationalGroup>,
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

        private IGroupRepository<RelationalGroup> This { get { return (IGroupRepository<RelationalGroup>)this; } }

        public void Add(Group item)
        {
            This.Add((RelationalGroup)item);
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
            This.Remove((RelationalGroup)item);
        }

        public void Update(Group item)
        {
            This.Update((RelationalGroup)item);
        }
    }
}