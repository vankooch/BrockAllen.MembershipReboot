using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Relational;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DefaultUserAccountRepository
           : DbContextUserAccountRepository<DefaultMembershipRebootDatabase, RelationalUserAccount>,
             IUserAccountRepository
    {
        public DefaultUserAccountRepository()
        {
        }

        public DefaultUserAccountRepository(string name)
            : base(new DefaultMembershipRebootDatabase(name))
        {
        }

        public DefaultUserAccountRepository(string name, string schemaName)
            : base(new DefaultMembershipRebootDatabase(name, schemaName))
        {
        }

        private IUserAccountRepository<RelationalUserAccount> This { get { return (IUserAccountRepository<RelationalUserAccount>)this; } }

        public void Add(UserAccount item)
        {
            This.Add((RelationalUserAccount)item);
        }

        public new UserAccount Create()
        {
            return This.Create();
        }

        public new UserAccount GetByCertificate(string tenant, string thumbprint)
        {
            return This.GetByCertificate(tenant, thumbprint);
        }

        public new UserAccount GetByEmail(string tenant, string email)
        {
            return This.GetByEmail(tenant, email);
        }

        public new UserAccount GetByID(System.Guid id)
        {
            return This.GetByID(id);
        }

        public new UserAccount GetByLinkedAccount(string tenant, string provider, string id)
        {
            return This.GetByLinkedAccount(tenant, provider, id);
        }

        public new UserAccount GetByMobilePhone(string tenant, string phone)
        {
            return This.GetByMobilePhone(tenant, phone);
        }

        public new UserAccount GetByUsername(string username)
        {
            return This.GetByUsername(username);
        }

        public new UserAccount GetByVerificationKey(string key)
        {
            return This.GetByVerificationKey(key);
        }

        UserAccount IUserAccountRepository<UserAccount>.GetByUsername(string tenant, string username)
        {
            return This.GetByUsername(tenant, username);
        }

        public void Remove(UserAccount item)
        {
            This.Remove((RelationalUserAccount)item);
        }

        public void Update(UserAccount item)
        {
            This.Update((RelationalUserAccount)item);
        }
    }
}