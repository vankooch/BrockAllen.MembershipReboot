-- /****** Object:  Database [MembershipReboot]    Script Date: 3/5/2014 10:41:33 PM ******/
CREATE SCHEMA membership_reboot;

-- /****** Object:  Table membership_reboot.group_childs    Script Date: 3/5/2014 10:41:33 PM ******/
-- Table: membership_reboot.group_childs
-- DROP TABLE membership_reboot.group_childs;

CREATE TABLE membership_reboot.group_childs
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	child_group_id uuid NOT NULL UNIQUE,
	CONSTRAINT group_childs_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.group_childs
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.group_childs TO pgsql;
GRANT ALL ON TABLE membership_reboot.group_childs TO postgres;
GRANT ALL ON TABLE membership_reboot.group_childs TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.group_childs_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.group_childs_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.group_childs_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.groups    Script Date: 3/5/2014 10:41:33 PM ******/
-- Table: membership_reboot.groups
-- DROP TABLE membership_reboot.groups;

CREATE TABLE membership_reboot.groups
(
	key serial NOT NULL,
	id uuid NOT NULL,
	tenant text NOT NULL,
	name text NOT NULL,
	created timestamp NOT NULL,
	last_updated timestamp NOT NULL,
	CONSTRAINT groups_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.groups
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.groups TO pgsql;
GRANT ALL ON TABLE membership_reboot.groups TO postgres;
GRANT ALL ON TABLE membership_reboot.groups TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.groups_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.groups_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.groups_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.linked_account_claims    Script Date: 3/5/2014 10:41:33 PM ******/
-- Table: membership_reboot.linked_account_claims
-- DROP TABLE membership_reboot.linked_account_claims;

CREATE TABLE membership_reboot.linked_account_claims
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	provider_name text NOT NULL UNIQUE,
	provider_account_id text NOT NULL UNIQUE,
	type_t text NOT NULL UNIQUE,
	value text NOT NULL UNIQUE,
	CONSTRAINT linked_account_claims_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.linked_account_claims
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.linked_account_claims TO pgsql;
GRANT ALL ON TABLE membership_reboot.linked_account_claims TO postgres;
GRANT ALL ON TABLE membership_reboot.linked_account_claims TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.linked_account_claims_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.linked_account_claims_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.linked_account_claims_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.linked_accounts    Script Date: 3/5/2014 10:41:33 PM ******/
-- Table: membership_reboot.linked_accounts
-- DROP TABLE membership_reboot.linked_accounts;

CREATE TABLE membership_reboot.linked_accounts
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	provider_name text NOT NULL UNIQUE,
	provider_account_id text NOT NULL UNIQUE,
	last_login timestamp NOT NULL,
	CONSTRAINT linked_accounts_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.linked_accounts
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.linked_accounts TO pgsql;
GRANT ALL ON TABLE membership_reboot.linked_accounts TO postgres;
GRANT ALL ON TABLE membership_reboot.linked_accounts TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.linked_accounts_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.linked_accounts_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.linked_accounts_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.password_reset_secrets    Script Date: 3/5/2014 10:41:34 PM ******/
-- Table: membership_reboot.password_reset_secrets
-- DROP TABLE membership_reboot.password_reset_secrets;

CREATE TABLE membership_reboot.password_reset_secrets
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	password_reset_secret_id uuid NOT NULL,
	question text NOT NULL UNIQUE,
	answer text NOT NULL,
	CONSTRAINT password_reset_secrets_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.password_reset_secrets
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.password_reset_secrets TO pgsql;
GRANT ALL ON TABLE membership_reboot.password_reset_secrets TO postgres;
GRANT ALL ON TABLE membership_reboot.password_reset_secrets TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.password_reset_secrets_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.password_reset_secrets_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.password_reset_secrets_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.two_factor_auth_tokens    Script Date: 3/5/2014 10:41:34 PM ******/
-- Table: membership_reboot.two_factor_auth_tokens
-- DROP TABLE membership_reboot.two_factor_auth_tokens;

CREATE TABLE membership_reboot.two_factor_auth_tokens
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	token text NOT NULL,
	issued timestamp NOT NULL,
	CONSTRAINT two_factor_auth_tokens_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.two_factor_auth_tokens
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.two_factor_auth_tokens TO pgsql;
GRANT ALL ON TABLE membership_reboot.two_factor_auth_tokens TO postgres;
GRANT ALL ON TABLE membership_reboot.two_factor_auth_tokens TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.two_factor_auth_tokens_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.two_factor_auth_tokens_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.two_factor_auth_tokens_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.user_accounts    Script Date: 3/5/2014 10:41:34 PM ******/
-- Table: membership_reboot.user_accounts
-- DROP TABLE membership_reboot.user_accounts;

CREATE TABLE membership_reboot.user_accounts
(
	key serial NOT NULL UNIQUE,
	id uuid NOT NULL,
	tenant text NOT NULL,
	username text NOT NULL,
	created timestamp NOT NULL,
	last_updated timestamp NOT NULL,
	is_account_closed boolean NOT NULL,
	account_closed timestamp NULL,
	is_login_allowed boolean NOT NULL,
	last_login timestamp NULL,
	last_failed_login timestamp NULL,
	failed_login_count integer NOT NULL,
	password_changed timestamp NULL,
	requires_password_reset boolean NOT NULL,
	email text NULL,
	is_account_verified boolean NOT NULL,
	last_failed_password_reset timestamp NULL,
	failed_password_reset_count integer NOT NULL,
	mobile_code text NULL,
	mobile_code_sent timestamp NULL,
	mobile_phone_number text NULL,
	mobile_phone_number_changed timestamp NULL,
	account_two_factor_auth_mode integer NOT NULL,
	current_two_factor_auth_status integer NOT NULL,
	verification_key text NULL,
	verification_purpose integer NULL,
	verification_key_sent timestamp NULL,
	verification_storage text NULL,
	hashed_password text NULL,
	CONSTRAINT user_accounts_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.user_accounts
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.user_accounts TO pgsql;
GRANT ALL ON TABLE membership_reboot.user_accounts TO postgres;
GRANT ALL ON TABLE membership_reboot.user_accounts TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.user_accounts_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.user_accounts_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.user_accounts_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.user_certificates    Script Date: 3/5/2014 10:41:34 PM ******/
-- Table: membership_reboot.user_certificates
-- DROP TABLE membership_reboot.user_certificates;

CREATE TABLE membership_reboot.user_certificates
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	thumbprint text NOT NULL UNIQUE,
	subject text NULL,
	CONSTRAINT user_certificates_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.user_certificates
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.user_certificates TO pgsql;
GRANT ALL ON TABLE membership_reboot.user_certificates TO postgres;
GRANT ALL ON TABLE membership_reboot.user_certificates TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.user_certificates_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.user_certificates_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.user_certificates_key_seq TO web_did_group;

-- /****** Object:  Table membership_reboot.user_claims    Script Date: 3/5/2014 10:41:34 PM ******/
-- Table: membership_reboot.user_claims
-- DROP TABLE membership_reboot.user_claims;

CREATE TABLE membership_reboot.user_claims
(
	key serial NOT NULL,
	parent_key integer NOT NULL,
	type_t text NOT NULL UNIQUE,
	value text NOT NULL UNIQUE,
	CONSTRAINT user_claims_pkey PRIMARY KEY (key)
)
WITH (
	OIDS=FALSE
);
ALTER TABLE membership_reboot.user_claims
	OWNER TO postgres;
GRANT ALL ON TABLE membership_reboot.user_claims TO pgsql;
GRANT ALL ON TABLE membership_reboot.user_claims TO postgres;
GRANT ALL ON TABLE membership_reboot.user_claims TO web_did_group;
-- Privileges for sequence
GRANT ALL ON TABLE membership_reboot.user_claims_key_seq TO pgsql;
GRANT ALL ON TABLE membership_reboot.user_claims_key_seq TO postgres;
GRANT ALL ON TABLE membership_reboot.user_claims_key_seq TO web_did_group;

-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_group_childs_parent_key
-- DROP INDEX ix_group_childs_parent_key;

CREATE INDEX ix_group_childs_parent_key ON membership_reboot.group_childs (parent_key);


-- /****** Object:  Index [IX_ID]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_uq_groups_id
-- DROP INDEX ix_uq_groups_id;

CREATE UNIQUE INDEX ix_uq_groups_id ON membership_reboot.groups (id);



-- /****** Object:  Index [IX_Tenant_Name]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_uq_groups_tenant
-- DROP INDEX ix_uq_groups_tenant;

CREATE UNIQUE INDEX ix_uq_groups_tenant ON membership_reboot.groups (tenant);

-- Index: ix_uq_groups_name
-- DROP INDEX ix_uq_groups_name;

CREATE UNIQUE INDEX ix_uq_groups_name ON membership_reboot.groups (name);


-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_linked_account_claims_parent_key
-- DROP INDEX ix_linked_account_claims_parent_key;

CREATE INDEX ix_linked_account_claims_parent_key ON membership_reboot.linked_account_claims (parent_key);


-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_linked_accounts_parent_key
-- DROP INDEX ix_linked_accounts_parent_key;

CREATE INDEX ix_linked_accounts_parent_key ON membership_reboot.linked_accounts (parent_key);



-- /****** Object:  Index [IX_ProviderName_ProviderAccountID]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_linked_accounts_provider_name
-- DROP INDEX ix_linked_accounts_provider_name;

CREATE INDEX ix_linked_accounts_provider_name ON membership_reboot.linked_accounts (provider_name);

-- Index: ix_linked_accounts_provider_account_id
-- DROP INDEX ix_linked_accounts_provider_account_id;

CREATE INDEX ix_linked_accounts_provider_account_id ON membership_reboot.linked_accounts (provider_account_id);


-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_password_reset_secrets_parent_key
-- DROP INDEX ix_password_reset_secrets_parent_key;

CREATE INDEX ix_password_reset_secrets_parent_key ON membership_reboot.password_reset_secrets (parent_key);


-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_two_factor_auth_tokens_parent_key
-- DROP INDEX ix_two_factor_auth_tokens_parent_key;

CREATE INDEX ix_two_factor_auth_tokens_parent_key ON membership_reboot.two_factor_auth_tokens (parent_key);


-- /****** Object:  Index [IX_ID]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_uq_user_accounts_id
-- DROP INDEX ix_uq_user_accounts_id;

CREATE UNIQUE INDEX ix_uq_user_accounts_id ON membership_reboot.user_accounts (id);



-- /****** Object:  Index [IX_Tenant_Email]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_user_accounts_tenant
-- DROP INDEX ix_user_accounts_tenant;

CREATE INDEX ix_user_accounts_tenant ON membership_reboot.user_accounts (tenant);

-- Index: ix_user_accounts_email
-- DROP INDEX ix_user_accounts_email;

CREATE INDEX ix_user_accounts_email ON membership_reboot.user_accounts (email);



-- /****** Object:  Index [IX_Tenant_Username]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_uq_user_accounts_tenant
-- DROP INDEX ix_uq_user_accounts_tenant;

CREATE UNIQUE INDEX ix_uq_user_accounts_tenant ON membership_reboot.user_accounts (tenant);

-- Index: ix_uq_user_accounts_username
-- DROP INDEX ix_uq_user_accounts_username;

CREATE UNIQUE INDEX ix_uq_user_accounts_username ON membership_reboot.user_accounts (username);



-- /****** Object:  Index [IX_Username]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_user_accounts_username
-- DROP INDEX ix_user_accounts_username;

CREATE INDEX ix_user_accounts_username ON membership_reboot.user_accounts (username);



-- /****** Object:  Index [IX_VerificationKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_user_accounts_verification_key
-- DROP INDEX ix_user_accounts_verification_key;

CREATE INDEX ix_user_accounts_verification_key ON membership_reboot.user_accounts (verification_key);


-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_user_certificates_parent_key
-- DROP INDEX ix_user_certificates_parent_key;

CREATE INDEX ix_user_certificates_parent_key ON membership_reboot.user_certificates (parent_key);



-- /****** Object:  Index [IX_Thumbprint]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_user_certificates_thumbprint
-- DROP INDEX ix_user_certificates_thumbprint;

CREATE INDEX ix_user_certificates_thumbprint ON membership_reboot.user_certificates (thumbprint);


-- /****** Object:  Index [IX_ParentKey]    Script Date: 3/5/2014 10:41:34 PM ******/
-- Index: ix_user_claims_parent_key
-- DROP INDEX ix_user_claims_parent_key;

CREATE INDEX ix_user_claims_parent_key ON membership_reboot.user_claims (parent_key);


ALTER TABLE membership_reboot.group_childs
	ADD CONSTRAINT fk_group_childs_groups_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.groups (key)
		ON DELETE CASCADE;

ALTER TABLE membership_reboot.linked_account_claims
	ADD CONSTRAINT fk_linked_account_claims_user_accounts_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.user_accounts (key)
		ON DELETE CASCADE;

ALTER TABLE membership_reboot.linked_accounts
	ADD CONSTRAINT fk_linked_accounts_user_accounts_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.user_accounts (key)
		ON DELETE CASCADE;

ALTER TABLE membership_reboot.password_reset_secrets
	ADD CONSTRAINT fk_password_reset_secrets_user_accounts_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.user_accounts (key)
		ON DELETE CASCADE;

ALTER TABLE membership_reboot.two_factor_auth_tokens
	ADD CONSTRAINT fk_two_factor_auth_tokens_user_accounts_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.user_accounts (key)
		ON DELETE CASCADE;

ALTER TABLE membership_reboot.user_certificates
	ADD CONSTRAINT fk_user_certificates_user_accounts_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.user_accounts (key)
		ON DELETE CASCADE;

ALTER TABLE membership_reboot.user_claims
	ADD CONSTRAINT fk_user_claims_user_accounts_parent_key
		FOREIGN KEY (parent_key)
		REFERENCES membership_reboot.user_accounts (key)
		ON DELETE CASCADE;