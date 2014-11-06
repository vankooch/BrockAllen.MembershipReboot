using System;
using System.Data.Entity;
using System.Linq;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Npgsql;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DbContextGroupRepository<Ctx, TGroup> :
        QueryableGroupRepository<TGroup>
        where Ctx : DbContext
        where TGroup : PgGroup
    {
        protected DbContext db;
        DbSet<TGroup> items;

        public DbContextGroupRepository(Ctx ctx)
        {
            this.db = ctx;
            this.items = db.Set<TGroup>();
        }

        protected virtual void SaveChanges()
        {
            db.SaveChanges();
        }

        protected override IQueryable<TGroup> Queryable
        {
            get { return items; }
        }

        public override TGroup Create()
        {
            return items.Create();
        }

        public override void Add(TGroup item)
        {
            items.Add(item);
            SaveChanges();
        }

        public override void Remove(TGroup item)
        {
            items.Remove(item);
            SaveChanges();
        }

        public override void Update(TGroup item)
        {
            var entry = db.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                items.Attach(item);
                entry.State = EntityState.Modified;
            }
            SaveChanges();
        }

        public override System.Collections.Generic.IEnumerable<TGroup> GetByChildID(Guid childGroupID)
        {
            var query =
                from g in items
                from c in g.ChildrenCollection
                where c.ChildGroupID == childGroupID
                select g;
            return query.ToArray();
        }
    }
}