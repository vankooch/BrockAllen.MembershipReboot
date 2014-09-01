using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrockAllen.MembershipReboot.Npgsql
{
    public class PgUserAccount<TKey, TUserClaim, TLinkedAccount, TLinkedAccountClaim, TPasswordResetSecret, TTwoFactorAuthToken, TUserCertificate> : UserAccount
        where TUserClaim : PgUserClaim, new()
        where TLinkedAccount : PgLinkedAccount, new()
        where TLinkedAccountClaim : PgLinkedAccountClaim, new()
        where TPasswordResetSecret : PgPasswordResetSecret, new()
        where TTwoFactorAuthToken : PgTwoFactorAuthToken, new()
        where TUserCertificate : PgUserCertificate, new()
    {
        public override IEnumerable<UserCertificate> Certificates
        {
            get { return UserCertificateCollection; }
        }

        public virtual ICollection<TUserClaim> ClaimCollection { get; set; }

        public override IEnumerable<UserClaim> Claims
        {
            get { return ClaimCollection; }
        }

        [Column("key", TypeName = "int4")]
        public virtual int Key { get; set; }

        public virtual ICollection<TLinkedAccountClaim> LinkedAccountClaimCollection { get; set; }

        public override IEnumerable<LinkedAccountClaim> LinkedAccountClaims
        {
            get { return LinkedAccountClaimCollection; }
        }

        public virtual ICollection<TLinkedAccount> LinkedAccountCollection { get; set; }

        public override IEnumerable<LinkedAccount> LinkedAccounts
        {
            get { return LinkedAccountCollection; }
        }

        public virtual ICollection<TPasswordResetSecret> PasswordResetSecretCollection { get; set; }

        public override IEnumerable<PasswordResetSecret> PasswordResetSecrets
        {
            get { return PasswordResetSecretCollection; }
        }

        public virtual ICollection<TTwoFactorAuthToken> TwoFactorAuthTokenCollection { get; set; }

        public override IEnumerable<TwoFactorAuthToken> TwoFactorAuthTokens
        {
            get { return TwoFactorAuthTokenCollection; }
        }

        public virtual ICollection<TUserCertificate> UserCertificateCollection { get; set; }

        protected internal override void AddCertificate(UserCertificate item)
        {
            UserCertificateCollection.Add(new TUserCertificate { ParentKey = this.Key, Thumbprint = item.Thumbprint, Subject = item.Subject });
        }

        protected internal override void AddClaim(UserClaim item)
        {
            ClaimCollection.Add(new TUserClaim { ParentKey = this.Key, Type = item.Type, Value = item.Value });
        }

        protected internal override void AddLinkedAccount(LinkedAccount item)
        {
            LinkedAccountCollection.Add(new TLinkedAccount { ParentKey = this.Key, ProviderName = item.ProviderName, ProviderAccountID = item.ProviderAccountID, LastLogin = item.LastLogin });
        }

        protected internal override void AddLinkedAccountClaim(LinkedAccountClaim item)
        {
            LinkedAccountClaimCollection.Add(new TLinkedAccountClaim { ParentKey = this.Key, ProviderName = item.ProviderName, ProviderAccountID = item.ProviderAccountID, Type = item.Type, Value = item.Value });
        }

        protected internal override void AddPasswordResetSecret(PasswordResetSecret item)
        {
            PasswordResetSecretCollection.Add(new TPasswordResetSecret { ParentKey = this.Key, PasswordResetSecretID = item.PasswordResetSecretID, Question = item.Question, Answer = item.Answer });
        }

        protected internal override void AddTwoFactorAuthToken(TwoFactorAuthToken item)
        {
            TwoFactorAuthTokenCollection.Add(new TTwoFactorAuthToken { ParentKey = this.Key, Token = item.Token, Issued = item.Issued });
        }

        protected internal override void RemoveCertificate(UserCertificate item)
        {
            UserCertificateCollection.Remove((TUserCertificate)item);
        }

        protected internal override void RemoveClaim(UserClaim item)
        {
            ClaimCollection.Remove((TUserClaim)item);
        }

        protected internal override void RemoveLinkedAccount(LinkedAccount item)
        {
            LinkedAccountCollection.Remove((TLinkedAccount)item);
        }

        protected internal override void RemoveLinkedAccountClaim(LinkedAccountClaim item)
        {
            LinkedAccountClaimCollection.Remove((TLinkedAccountClaim)item);
        }

        protected internal override void RemovePasswordResetSecret(PasswordResetSecret item)
        {
            PasswordResetSecretCollection.Remove((TPasswordResetSecret)item);
        }

        protected internal override void RemoveTwoFactorAuthToken(TwoFactorAuthToken item)
        {
            TwoFactorAuthTokenCollection.Remove((TTwoFactorAuthToken)item);
        }
    }

    public class PgUserAccount : PgUserAccount<int, PgUserClaim, PgLinkedAccount, PgLinkedAccountClaim, PgPasswordResetSecret, PgTwoFactorAuthToken, PgUserCertificate> { }
}