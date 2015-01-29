using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using BrockAllen.MembershipReboot.Npgsql;

namespace SiCo.MembershipReboot.Ef.Npgsql
{
    public static class DbModelBuilderExtensions
    {
        public static void ConfigureMembershipRebootGroups<TGroup>(this DbModelBuilder modelBuilder)
            where TGroup : PgGroup
        {
            modelBuilder.ConfigureMembershipRebootGroups<TGroup>(null);
        }

        public static void ConfigureMembershipRebootGroups<TGroup>(this DbModelBuilder modelBuilder, string schemaName)
            where TGroup : PgGroup
        {
            modelBuilder.Entity<TGroup>()
                .HasKey(x => x.Key).ToTable("groups", schemaName);

            modelBuilder.Entity<TGroup>().HasMany(x => x.ChildrenCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<PgGroupChild>()
                .HasKey(x => x.Key).ToTable("group_childs", schemaName);
        }

        public static void ConfigureMembershipRebootUserAccounts<TKey, TAccount, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>(this DbModelBuilder modelBuilder)
            where TAccount : PgUserAccount<TKey, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>
            where TUserClaim : PgUserClaim, new()
            where TLinkedAccount : PgLinkedAccount, new()
            where TLinkedAccountClaim : PgLinkedAccountClaim, new()
            where TPasswordResetSecret : PgPasswordResetSecret, new()
            where TTwoFactorAuthToken : PgTwoFactorAuthToken, new()
            where TUserCertificate : PgUserCertificate, new()
        {
            modelBuilder.ConfigureMembershipRebootUserAccounts<TKey, TAccount, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>(null);
        }

        public static void ConfigureMembershipRebootUserAccounts<TKey, TAccount, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>(this DbModelBuilder modelBuilder, string schemaName)
            where TAccount : PgUserAccount<TKey, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>
            where TUserClaim : PgUserClaim, new()
            where TLinkedAccount : PgLinkedAccount, new()
            where TLinkedAccountClaim : PgLinkedAccountClaim, new()
            where TPasswordResetSecret : PgPasswordResetSecret, new()
            where TTwoFactorAuthToken : PgTwoFactorAuthToken, new()
            where TUserCertificate : PgUserCertificate, new()
        {
            modelBuilder.Entity<TAccount>()
                .HasKey(x => x.Key).ToTable("user_accounts", schemaName);

            modelBuilder.Entity<TAccount>().HasMany(x => x.PasswordResetSecretCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<TPasswordResetSecret>()
                .HasKey(x => x.Key).ToTable("password_reset_secrets", schemaName);

            modelBuilder.Entity<TAccount>().HasMany(x => x.TwoFactorAuthTokenCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<TTwoFactorAuthToken>()
                .HasKey(x => x.Key).ToTable("two_factor_auth_tokens", schemaName);

            modelBuilder.Entity<TAccount>().HasMany(x => x.UserCertificateCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<TUserCertificate>()
                .HasKey(x => x.Key).ToTable("user_certificates", schemaName);

            modelBuilder.Entity<TAccount>().HasMany(x => x.ClaimCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<TUserClaim>()
                .HasKey(x => x.Key).ToTable("user_claims", schemaName);

            modelBuilder.Entity<TAccount>().HasMany(x => x.LinkedAccountCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<TLinkedAccount>()
                .HasKey(x => x.Key).ToTable("linked_accounts", schemaName);

            modelBuilder.Entity<TAccount>().HasMany(x => x.LinkedAccountClaimCollection)
                .WithOptional().HasForeignKey(x => x.ParentKey).WillCascadeOnDelete();
            modelBuilder.Entity<TLinkedAccountClaim>()
                .HasKey(x => x.Key).ToTable("linked_account_claims", schemaName);
        }

        public static void ConfigureMembershipRebootUserAccounts<TAccount>(this DbModelBuilder modelBuilder)
            where TAccount : PgUserAccount
        {
            modelBuilder.ConfigureMembershipRebootUserAccounts<int, TAccount, PgUserClaim, PgLinkedAccount, PgLinkedAccountClaim, PgPasswordResetSecret, PgTwoFactorAuthToken, PgUserCertificate>(null);
        }

        public static void ConfigureMembershipRebootUserAccounts<TAccount>(this DbModelBuilder modelBuilder, string schemaName)
            where TAccount : PgUserAccount
        {
            modelBuilder.ConfigureMembershipRebootUserAccounts<int, TAccount, PgUserClaim, PgLinkedAccount, PgLinkedAccountClaim, PgPasswordResetSecret, PgTwoFactorAuthToken, PgUserCertificate>(schemaName);
        }

        public static void RegisterGroupChildTablesForDelete<TGroup>(this DbContext ctx)
            where TGroup : PgGroup
        {
            ctx.Set<TGroup>().Local.CollectionChanged +=
                delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (TGroup group in e.NewItems)
                        {
                            group.ChildrenCollection.RegisterDeleteOnRemove(ctx);
                        }
                    }
                };
        }

        public static void RegisterUserAccountChildTablesForDelete<TKey, TAccount, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>(this DbContext ctx)
            where TAccount : PgUserAccount<TKey, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate>
            where TUserClaim : PgUserClaim, new()
            where TLinkedAccount : PgLinkedAccount, new()
            where TLinkedAccountClaim : PgLinkedAccountClaim, new()
            where TPasswordResetSecret : PgPasswordResetSecret, new()
            where TTwoFactorAuthToken : PgTwoFactorAuthToken, new()
            where TUserCertificate : PgUserCertificate, new()
        {
            ctx.Set<TAccount>().Local.CollectionChanged +=
                delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (TAccount account in e.NewItems)
                        {
                            account.ClaimCollection.RegisterDeleteOnRemove(ctx);
                            account.LinkedAccountClaimCollection.RegisterDeleteOnRemove(ctx);
                            account.LinkedAccountCollection.RegisterDeleteOnRemove(ctx);
                            account.PasswordResetSecretCollection.RegisterDeleteOnRemove(ctx);
                            account.TwoFactorAuthTokenCollection.RegisterDeleteOnRemove(ctx);
                            account.UserCertificateCollection.RegisterDeleteOnRemove(ctx);
                        }
                    }
                };
        }

        public static void RegisterUserAccountChildTablesForDelete<TAccount>(this DbContext ctx)
            where TAccount : PgUserAccount
        {
            ctx.RegisterUserAccountChildTablesForDelete<int, TAccount, PgUserClaim, PgLinkedAccount, PgLinkedAccountClaim, PgPasswordResetSecret, PgTwoFactorAuthToken, PgUserCertificate>();
        }

        internal static void RegisterDeleteOnRemove<TChild>(this ICollection<TChild> collection, DbContext ctx)
            where TChild : class
        {
            var entities = collection as EntityCollection<TChild>;
            if (entities != null)
            {
                entities.AssociationChanged += delegate(object sender, CollectionChangeEventArgs e)
                {
                    if (e.Action == CollectionChangeAction.Remove)
                    {
                        var entity = e.Element as TChild;
                        if (entity != null)
                        {
                            ctx.Entry<TChild>(entity).State = EntityState.Deleted;
                        }
                    }
                };
            }
        }
    }
}