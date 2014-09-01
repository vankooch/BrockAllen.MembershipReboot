﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BrockAllen.MembershipReboot.Npgsql
{
    public class PgTwoFactorAuthToken : TwoFactorAuthToken
    {
        public PgTwoFactorAuthToken()
        {
            this.Key = 0;
            this.ParentKey = null;
        }

        [Column("key", TypeName = "int4")]
        public virtual int Key { get; set; }

        [Column("parent_key", TypeName = "int4")]
        public virtual int? ParentKey { get; set; }
    }
}