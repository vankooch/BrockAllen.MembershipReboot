using System.Data.Entity;
using BrockAllen.MembershipReboot.Npgsql;

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
            this.RegisterUserAccountChildTablesForDelete<PgUserAccount>();
            this.RegisterGroupChildTablesForDelete<PgGroup>();

            Database.SetInitializer<DefaultMembershipRebootDatabase>(null);
        }

        public DbSet<PgGroup> Groups { get; set; }

        public string SchemaName { get; private set; }

        public DbSet<PgUserAccount> Users { get; set; }

        internal static string CONNECTION_STRING { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region PostgreSQL-Convetions

            // Groups Table
            modelBuilder.Entity<PgGroup>().ToTable("groups", this.SchemaName);
            //modelBuilder.Entity<PgGroup>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<PgGroup>().Property(t => t.ID).HasColumnName("id").HasColumnType("uuid");
            modelBuilder.Entity<PgGroup>().Property(t => t.Tenant).HasColumnName("tenant").HasColumnType("text");
            modelBuilder.Entity<PgGroup>().Property(t => t.Name).HasColumnName("name").HasColumnType("text");
            modelBuilder.Entity<PgGroup>().Property(t => t.Created).HasColumnName("created").HasColumnType("timestamp");
            modelBuilder.Entity<PgGroup>().Property(t => t.LastUpdated).HasColumnName("last_updated").HasColumnType("timestamp");

            // GroupChilds Table
            modelBuilder.Entity<PgGroupChild>().ToTable("group_childs", this.SchemaName);
            //modelBuilder.Entity<PgGroupChild>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<PgGroupChild>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgGroupChild>().Property(t => t.ChildGroupID).HasColumnName("child_group_id").HasColumnType("uuid");

            // UserAccounts Table
            modelBuilder.Entity<PgUserAccount>().ToTable("user_accounts", this.SchemaName);
            //modelBuilder.Entity<PgUserAccount>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.ID).HasColumnName("id").HasColumnType("uuid");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.Tenant).HasColumnName("tenant").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.Username).HasColumnName("username").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.Created).HasColumnName("created").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.LastUpdated).HasColumnName("last_updated").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.IsAccountClosed).HasColumnName("is_account_closed").HasColumnType("bool");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.AccountClosed).HasColumnName("account_closed").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.IsLoginAllowed).HasColumnName("is_login_allowed").HasColumnType("bool");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.LastLogin).HasColumnName("last_login").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.LastFailedLogin).HasColumnName("last_failed_login").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.FailedLoginCount).HasColumnName("failed_login_count").HasColumnType("int4");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.PasswordChanged).HasColumnName("password_changed").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.RequiresPasswordReset).HasColumnName("requires_password_reset").HasColumnType("bool");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.Email).HasColumnName("email").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.IsAccountVerified).HasColumnName("is_account_verified").HasColumnType("bool");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.LastFailedPasswordReset).HasColumnName("last_failed_password_reset").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.FailedPasswordResetCount).HasColumnName("failed_password_reset_count").HasColumnType("int4");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.MobileCode).HasColumnName("mobile_code").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.MobileCodeSent).HasColumnName("mobile_code_sent").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.MobilePhoneNumber).HasColumnName("mobile_phone_number").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.MobilePhoneNumberChanged).HasColumnName("mobile_phone_number_changed").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.AccountTwoFactorAuthMode).HasColumnName("account_two_factor_auth_mode").HasColumnType("int4");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.CurrentTwoFactorAuthStatus).HasColumnName("current_two_factor_auth_status").HasColumnType("int4");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.VerificationKey).HasColumnName("verification_key").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.VerificationPurpose).HasColumnName("verification_purpose").HasColumnType("int4");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.VerificationKeySent).HasColumnName("verification_key_sent").HasColumnType("timestamp");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.VerificationStorage).HasColumnName("verification_storage").HasColumnType("text");
            modelBuilder.Entity<PgUserAccount>().Property(t => t.HashedPassword).HasColumnName("hashed_password").HasColumnType("text");

            // UserClaims Table
            modelBuilder.Entity<PgUserClaim>().ToTable("user_claims", this.SchemaName);
            //modelBuilder.Entity<RelationalUserClaim>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<RelationalUserClaim>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgUserClaim>().Property(t => t.Type).HasColumnName("type_t").HasColumnType("text");
            modelBuilder.Entity<PgUserClaim>().Property(t => t.Value).HasColumnName("value").HasColumnType("text");

            // LinkedAccountClaims Table
            modelBuilder.Entity<PgLinkedAccountClaim>().ToTable("linked_account_claims", this.SchemaName);
            //modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<RelationalLinkedAccountClaim>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgLinkedAccountClaim>().Property(t => t.ProviderName).HasColumnName("provider_name").HasColumnType("text");
            modelBuilder.Entity<PgLinkedAccountClaim>().Property(t => t.ProviderAccountID).HasColumnName("provider_account_id").HasColumnType("text");
            modelBuilder.Entity<PgLinkedAccountClaim>().Property(t => t.Type).HasColumnName("type_t").HasColumnType("text");
            modelBuilder.Entity<PgLinkedAccountClaim>().Property(t => t.Value).HasColumnName("value").HasColumnType("text");

            // LinkedAccount Table
            modelBuilder.Entity<PgLinkedAccount>().ToTable("linked_accounts", this.SchemaName);
            //modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<RelationalLinkedAccount>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgLinkedAccount>().Property(t => t.ProviderName).HasColumnName("provider_name").HasColumnType("text");
            modelBuilder.Entity<PgLinkedAccount>().Property(t => t.ProviderAccountID).HasColumnName("provider_account_id").HasColumnType("text");
            modelBuilder.Entity<PgLinkedAccount>().Property(t => t.LastLogin).HasColumnName("last_login").HasColumnType("timestamp");

            // PasswordResetSecrets Table
            modelBuilder.Entity<PgPasswordResetSecret>().ToTable("password_reset_secrets", this.SchemaName);
            //modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<RelationalPasswordResetSecret>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgPasswordResetSecret>().Property(t => t.PasswordResetSecretID).HasColumnName("password_reset_secret_id").HasColumnType("uuid");
            modelBuilder.Entity<PgPasswordResetSecret>().Property(t => t.Question).HasColumnName("question").HasColumnType("text");
            modelBuilder.Entity<PgPasswordResetSecret>().Property(t => t.Answer).HasColumnName("answer").HasColumnType("text");

            // TwoFactorAuthTokens Table
            modelBuilder.Entity<PgTwoFactorAuthToken>().ToTable("two_factor_auth_tokens", this.SchemaName);
            //modelBuilder.Entity<RelationalTwoFactorAuthToken>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<RelationalTwoFactorAuthToken>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgTwoFactorAuthToken>().Property(t => t.Token).HasColumnName("token").HasColumnType("text");
            modelBuilder.Entity<PgTwoFactorAuthToken>().Property(t => t.Issued).HasColumnName("issued").HasColumnType("timestamp");

            // UserCertificates Table
            modelBuilder.Entity<PgUserCertificate>().ToTable("user_certificates", this.SchemaName);
            //modelBuilder.Entity<RelationalUserCertificate>().Property(t => t.Key).HasColumnName("key").HasColumnType("int4");
            //modelBuilder.Entity<RelationalUserCertificate>().Property(t => t.ParentKey).HasColumnName("parent_key").HasColumnType("int4");
            modelBuilder.Entity<PgUserCertificate>().Property(t => t.Thumbprint).HasColumnName("thumbprint").HasColumnType("text");
            modelBuilder.Entity<PgUserCertificate>().Property(t => t.Subject).HasColumnName("subject").HasColumnType("text");

            #endregion PostgreSQL-Convetions

            modelBuilder.ConfigureMembershipRebootUserAccounts<PgUserAccount>(this.SchemaName);
            modelBuilder.ConfigureMembershipRebootGroups<PgGroup>(this.SchemaName);
        }
    }
}