using System;
using System.Data.Entity;
using System.Linq;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Relational;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DbContextUserAccountRepository<Ctx, TAccount> :
        QueryableUserAccountRepository<TAccount>, IDisposable
        where Ctx : DbContext, new()
        where TAccount : RelationalUserAccount
    {
        protected DbContext db;
        protected bool isContextOwner;
        private DbSet<TAccount> items;

        public DbContextUserAccountRepository()
            : this(new Ctx())
        {
            isContextOwner = true;
        }

        public DbContextUserAccountRepository(Ctx ctx)
        {
            this.db = ctx;
            this.items = db.Set<TAccount>();
        }

        protected override IQueryable<TAccount> Queryable
        {
            get
            {
                CheckDisposed();
                return this.items;
            }
        }

        public override void Add(TAccount item)
        {
            CheckDisposed();
            items.Add(item);
            SaveChanges();
        }

        public override TAccount Create()
        {
            CheckDisposed();
            return items.Create();
        }

        public void Dispose()
        {
            if (isContextOwner)
            {
                db.TryDispose();
            }
            db = null;
            items = null;
        }

        public override TAccount GetByCertificate(string tenant, string thumbprint)
        {
            var q =
                from a in items
                from c in a.UserCertificateCollection
                where c.Thumbprint == thumbprint && a.Tenant == tenant
                select a;
            return q.SingleOrDefault();
        }

        public override TAccount GetByLinkedAccount(string tenant, string provider, string id)
        {
            var q =
                from a in items
                from la in a.LinkedAccountCollection
                where la.ProviderName == provider && la.ProviderAccountID == id && a.Tenant == tenant
                select a;
            return q.SingleOrDefault();
        }

        public override void Remove(TAccount item)
        {
            CheckDisposed();
            items.Remove(item);
            SaveChanges();
        }

        public override void Update(TAccount item)
        {
            CheckDisposed();

            var entry = db.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                items.Attach(item);
                entry.State = EntityState.Modified;
            }
            SaveChanges();
        }

        protected virtual void SaveChanges()
        {
            db.SaveChanges();
        }

        private void CheckDisposed()
        {
            if (db == null)
            {
                throw new ObjectDisposedException("DbContextUserAccountRepository");
            }
        }
    }
}