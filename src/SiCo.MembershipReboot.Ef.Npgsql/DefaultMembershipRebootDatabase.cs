using System.Configuration;
using System.Data.Entity;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Relational;
using System.Data.Entity.Migrations.History; 

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public class DefaultMembershipRebootDatabase : DbContext
    {
        public DefaultMembershipRebootDatabase()
            : this("name=MembershipRebootNpgsql", "membership_reboot")
        {
        }

        public DefaultMembershipRebootDatabase(string nameOrConnectionString)
            : this(nameOrConnectionString, "membership_reboot")
        {
        }

        public DefaultMembershipRebootDatabase(string nameOrConnectionString, string schemaName)
            : base(nameOrConnectionString)
        {
            //CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings[nameOrConnectionString].ConnectionString;
            this.SchemaName = schemaName;
            this.RegisterUserAccountChildTablesForDelete<RelationalUserAccount>();
            this.RegisterGroupChildTablesForDelete<RelationalGroup>();

            Database.SetInitializer<DefaultMembershipRebootDatabase>(null);

        }

        public DbSet<RelationalGroup> Groups { get; set; }

        public string SchemaName { get; private set; }

        public DbSet<RelationalUserAccount> Users { get; set; }

        internal static string CONNECTION_STRING { get; private set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region PostgreSQL-Convetions

            // Groups Table
            modelBuilder.Entity<RelationalGroup>().ToTable("groups", this.SchemaName);
            modelBuilder.Entity<RelationalGroup>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalGroup>().Property(t => t.ID).HasColumnName("id").HasColumnType("uuid");
            modelBuilder.Entity<RelationalGroup>().Property(t => t.Tenant).HasColumnName("tenant").HasColumnType("text");
            modelBuilder.Entity<RelationalGroup>().Property(t => t.Name).HasColumnName("name").HasColumnType("text");
            modelBuilder.Entity<RelationalGroup>().Property(t => t.Created).HasColumnName("created").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalGroup>().Property(t => t.LastUpdated).HasColumnName("last_updated").HasColumnType("timestamp");

            // GroupChilds Table
            modelBuilder.Entity<RelationalGroupChild>().ToTable("group_childs", this.SchemaName);
            modelBuilder.Entity<RelationalGroupChild>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalGroupChild>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalGroupChild>().Property(t => t.ChildGroupID).HasColumnName("child_group_id").HasColumnType("uuid");

            // UserAccounts Table
            modelBuilder.Entity<RelationalUserAccount>().ToTable("user_accounts", this.SchemaName);
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.ID).HasColumnName("id").HasColumnType("uuid");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.Tenant).HasColumnName("tenant").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.Username).HasColumnName("username").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.Created).HasColumnName("created").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.LastUpdated).HasColumnName("last_updated").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.IsAccountClosed).HasColumnName("is_account_closed").HasColumnType("bool");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.AccountClosed).HasColumnName("account_closed").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.IsLoginAllowed).HasColumnName("is_login_allowed").HasColumnType("bool");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.LastLogin).HasColumnName("last_login").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.LastFailedLogin).HasColumnName("last_failed_login").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.FailedLoginCount).HasColumnName("failed_login_count").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.PasswordChanged).HasColumnName("password_changed").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.RequiresPasswordReset).HasColumnName("requires_password_reset").HasColumnType("bool");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.Email).HasColumnName("email").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.IsAccountVerified).HasColumnName("is_account_verified").HasColumnType("bool");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.LastFailedPasswordReset).HasColumnName("last_failed_password_reset").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.FailedPasswordResetCount).HasColumnName("failed_password_reset_count").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.MobileCode).HasColumnName("mobile_code").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.MobileCodeSent).HasColumnName("mobile_code_sent").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.MobilePhoneNumber).HasColumnName("mobile_phone_number").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.MobilePhoneNumberChanged).HasColumnName("mobile_phone_number_changed").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.AccountTwoFactorAuthMode).HasColumnName("account_two_factor_auth_mode").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.CurrentTwoFactorAuthStatus).HasColumnName("current_two_factor_auth_status").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.VerificationKey).HasColumnName("verification_key").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.VerificationPurpose).HasColumnName("verification_purpose").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.VerificationKeySent).HasColumnName("verification_key_sent").HasColumnType("timestamp");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.VerificationStorage).HasColumnName("verification_storage").HasColumnType("text");
            modelBuilder.Entity<RelationalUserAccount>().Property(t => t.HashedPassword).HasColumnName("hashed_password").HasColumnType("text");

            // UserClaims Table
            modelBuilder.Entity<RelationalUserClaim>().ToTable("user_claims", this.SchemaName);
            modelBuilder.Entity<RelationalUserClaim>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserClaim>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserClaim>().Property(t => t.Type).HasColumnName("type_t").HasColumnType("text");
            modelBuilder.Entity<RelationalUserClaim>().Property(t => t.Value).HasColumnName("value").HasColumnType("text");

            // LinkedAccountClaims Table
            modelBuilder.Entity<RelationalLinkedAccountClaim>().ToTable("linked_account_claims", this.SchemaName);
            modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.ProviderName).HasColumnName("provider_name").HasColumnType("text");
            modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.ProviderAccountID).HasColumnName("provider_account_id").HasColumnType("text");
            modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.Type).HasColumnName("type_t").HasColumnType("text");
            modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.Value).HasColumnName("value").HasColumnType("text");

            // LinkedAccount Table
            modelBuilder.Entity<RelationalLinkedAccount>().ToTable("linked_accounts", this.SchemaName);
            modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.ProviderName).HasColumnName("provider_name").HasColumnType("text");
            modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.ProviderAccountID).HasColumnName("provider_account_id").HasColumnType("text");
            modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.LastLogin).HasColumnName("last_login").HasColumnType("timestamp");

            // PasswordResetSecrets Table
            modelBuilder.Entity<RelationalPasswordResetSecret>().ToTable("password_reset_secrets", this.SchemaName);
            modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.PasswordResetSecretID).HasColumnName("password_reset_secret_id").HasColumnType("uuid");
            modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.Question).HasColumnName("question").HasColumnType("text");
            modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.Answer).HasColumnName("answer").HasColumnType("text");

            // TwoFactorAuthTokens Table
            modelBuilder.Entity<RelationalTwoFactorAuthToken>().ToTable("two_factor_auth_tokens", this.SchemaName);
            modelBuilder.Entity<RelationalTwoFactorAuthToken>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalTwoFactorAuthToken>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalTwoFactorAuthToken>().Property(t => t.Token).HasColumnName("token").HasColumnType("text");
            modelBuilder.Entity<RelationalTwoFactorAuthToken>().Property(t => t.Issued).HasColumnName("issued").HasColumnType("timestamp");

            // UserCertificates Table
            modelBuilder.Entity<RelationalUserCertificate>().ToTable("user_certificates", this.SchemaName);
            modelBuilder.Entity<RelationalUserCertificate>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserCertificate>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<RelationalUserCertificate>().Property(t => t.Thumbprint).HasColumnName("thumbprint").HasColumnType("text");
            modelBuilder.Entity<RelationalUserCertificate>().Property(t => t.Subject).HasColumnName("subject").HasColumnType("text");

            #endregion PostgreSQL-Convetions

            modelBuilder.ConfigureMembershipRebootUserAccounts<RelationalUserAccount>(this.SchemaName);
            modelBuilder.ConfigureMembershipRebootGroups<RelationalGroup>(this.SchemaName);
        }
    }
}