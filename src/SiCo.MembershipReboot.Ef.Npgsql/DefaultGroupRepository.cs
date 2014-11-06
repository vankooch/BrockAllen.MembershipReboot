using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Npgsql;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DefaultGroupRepository
          : DbContextGroupRepository<DefaultMembershipRebootDatabase, PgGroup>,
            IGroupRepository
    {
        public DefaultGroupRepository(DefaultMembershipRebootDatabase ctx)
            : base(ctx)
        {
        }

        IGroupRepository<PgGroup> This { get { return (IGroupRepository<PgGroup>)this; } }

        public new Group Create()
        {
            return This.Create();
        }

        public void Add(Group item)
        {
            This.Add((PgGroup)item);
        }

        public void Remove(Group item)
        {
            This.Remove((PgGroup)item);
        }

        public void Update(Group item)
        {
            This.Update((PgGroup)item);
        }

        public new Group GetByID(System.Guid id)
        {
            return This.GetByID(id);
        }

        public new Group GetByName(string tenant, string name)
        {
            return This.GetByName(tenant, name);
        }

        public new System.Collections.Generic.IEnumerable<Group> GetByIDs(System.Guid[] ids)
        {
            return This.GetByIDs(ids);
        }

        public new System.Collections.Generic.IEnumerable<Group> GetByChildID(System.Guid childGroupID)
        {
            return This.GetByChildID(childGroupID);
        }
    }
}