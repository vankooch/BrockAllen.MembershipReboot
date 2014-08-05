--
-- PostgreSQL database dump
--

-- Dumped from database version 9.3.2
-- Dumped by pg_dump version 9.3.1
-- Started on 2014-08-06 01:12:12

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 7 (class 2615 OID 473490)
-- Name: membership_reboot; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA membership_reboot;


ALTER SCHEMA membership_reboot OWNER TO postgres;

SET search_path = membership_reboot, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 175 (class 1259 OID 473505)
-- Name: group_childs; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE group_childs (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    child_group_id uuid NOT NULL
);


ALTER TABLE membership_reboot.group_childs OWNER TO postgres;

--
-- TOC entry 174 (class 1259 OID 473503)
-- Name: group_childs_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE group_childs_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.group_childs_key_seq OWNER TO postgres;

--
-- TOC entry 2055 (class 0 OID 0)
-- Dependencies: 174
-- Name: group_childs_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE group_childs_key_seq OWNED BY group_childs.key;


--
-- TOC entry 173 (class 1259 OID 473494)
-- Name: groups; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE groups (
    key integer NOT NULL,
    id uuid NOT NULL,
    tenant text NOT NULL,
    name text NOT NULL,
    created timestamp without time zone NOT NULL,
    last_updated timestamp without time zone NOT NULL
);


ALTER TABLE membership_reboot.groups OWNER TO postgres;

--
-- TOC entry 172 (class 1259 OID 473492)
-- Name: groups_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE groups_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.groups_key_seq OWNER TO postgres;

--
-- TOC entry 2056 (class 0 OID 0)
-- Dependencies: 172
-- Name: groups_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE groups_key_seq OWNED BY groups.key;


--
-- TOC entry 181 (class 1259 OID 473535)
-- Name: linked_account_claims; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE linked_account_claims (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    provider_name text NOT NULL,
    provider_account_id text NOT NULL,
    type_t text NOT NULL,
    value text NOT NULL
);


ALTER TABLE membership_reboot.linked_account_claims OWNER TO postgres;

--
-- TOC entry 180 (class 1259 OID 473533)
-- Name: linked_account_claims_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE linked_account_claims_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.linked_account_claims_key_seq OWNER TO postgres;

--
-- TOC entry 2057 (class 0 OID 0)
-- Dependencies: 180
-- Name: linked_account_claims_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE linked_account_claims_key_seq OWNED BY linked_account_claims.key;


--
-- TOC entry 183 (class 1259 OID 473546)
-- Name: linked_accounts; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE linked_accounts (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    provider_name text NOT NULL,
    provider_account_id text NOT NULL,
    last_login timestamp without time zone NOT NULL
);


ALTER TABLE membership_reboot.linked_accounts OWNER TO postgres;

--
-- TOC entry 182 (class 1259 OID 473544)
-- Name: linked_accounts_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE linked_accounts_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.linked_accounts_key_seq OWNER TO postgres;

--
-- TOC entry 2058 (class 0 OID 0)
-- Dependencies: 182
-- Name: linked_accounts_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE linked_accounts_key_seq OWNED BY linked_accounts.key;


--
-- TOC entry 185 (class 1259 OID 473557)
-- Name: password_reset_secrets; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE password_reset_secrets (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    password_reset_secret_id uuid NOT NULL,
    question text NOT NULL,
    answer text NOT NULL
);


ALTER TABLE membership_reboot.password_reset_secrets OWNER TO postgres;

--
-- TOC entry 184 (class 1259 OID 473555)
-- Name: password_reset_secrets_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE password_reset_secrets_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.password_reset_secrets_key_seq OWNER TO postgres;

--
-- TOC entry 2059 (class 0 OID 0)
-- Dependencies: 184
-- Name: password_reset_secrets_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE password_reset_secrets_key_seq OWNED BY password_reset_secrets.key;


--
-- TOC entry 187 (class 1259 OID 473568)
-- Name: two_factor_auth_tokens; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE two_factor_auth_tokens (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    token text NOT NULL,
    issued timestamp without time zone NOT NULL
);


ALTER TABLE membership_reboot.two_factor_auth_tokens OWNER TO postgres;

--
-- TOC entry 186 (class 1259 OID 473566)
-- Name: two_factor_auth_tokens_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE two_factor_auth_tokens_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.two_factor_auth_tokens_key_seq OWNER TO postgres;

--
-- TOC entry 2060 (class 0 OID 0)
-- Dependencies: 186
-- Name: two_factor_auth_tokens_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE two_factor_auth_tokens_key_seq OWNED BY two_factor_auth_tokens.key;


--
-- TOC entry 177 (class 1259 OID 473513)
-- Name: user_accounts; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE user_accounts (
    key integer NOT NULL,
    id uuid NOT NULL,
    tenant text NOT NULL,
    username text NOT NULL,
    created timestamp without time zone NOT NULL,
    last_updated timestamp without time zone NOT NULL,
    is_account_closed boolean NOT NULL,
    account_closed timestamp without time zone,
    is_login_allowed boolean NOT NULL,
    last_login timestamp without time zone,
    last_failed_login timestamp without time zone,
    failed_login_count integer NOT NULL,
    password_changed timestamp without time zone,
    requires_password_reset boolean NOT NULL,
    email text,
    is_account_verified boolean NOT NULL,
    last_failed_password_reset timestamp without time zone,
    failed_password_reset_count integer NOT NULL,
    mobile_code text,
    mobile_code_sent timestamp without time zone,
    mobile_phone_number text,
    mobile_phone_number_changed timestamp without time zone,
    account_two_factor_auth_mode integer NOT NULL,
    current_two_factor_auth_status integer NOT NULL,
    verification_key text,
    verification_purpose integer,
    verification_key_sent timestamp without time zone,
    verification_storage text,
    hashed_password text
);


ALTER TABLE membership_reboot.user_accounts OWNER TO postgres;

--
-- TOC entry 176 (class 1259 OID 473511)
-- Name: user_accounts_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE user_accounts_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.user_accounts_key_seq OWNER TO postgres;

--
-- TOC entry 2061 (class 0 OID 0)
-- Dependencies: 176
-- Name: user_accounts_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE user_accounts_key_seq OWNED BY user_accounts.key;


--
-- TOC entry 189 (class 1259 OID 473579)
-- Name: user_certificates; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE user_certificates (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    thumbprint text NOT NULL,
    subject text
);


ALTER TABLE membership_reboot.user_certificates OWNER TO postgres;

--
-- TOC entry 188 (class 1259 OID 473577)
-- Name: user_certificates_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE user_certificates_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.user_certificates_key_seq OWNER TO postgres;

--
-- TOC entry 2062 (class 0 OID 0)
-- Dependencies: 188
-- Name: user_certificates_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE user_certificates_key_seq OWNED BY user_certificates.key;


--
-- TOC entry 179 (class 1259 OID 473524)
-- Name: user_claims; Type: TABLE; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE TABLE user_claims (
    key integer NOT NULL,
    parent_key integer NOT NULL,
    type_t text NOT NULL,
    value text NOT NULL
);


ALTER TABLE membership_reboot.user_claims OWNER TO postgres;

--
-- TOC entry 178 (class 1259 OID 473522)
-- Name: user_claims_key_seq; Type: SEQUENCE; Schema: membership_reboot; Owner: postgres
--

CREATE SEQUENCE user_claims_key_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE membership_reboot.user_claims_key_seq OWNER TO postgres;

--
-- TOC entry 2063 (class 0 OID 0)
-- Dependencies: 178
-- Name: user_claims_key_seq; Type: SEQUENCE OWNED BY; Schema: membership_reboot; Owner: postgres
--

ALTER SEQUENCE user_claims_key_seq OWNED BY user_claims.key;


--
-- TOC entry 1886 (class 2604 OID 473508)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY group_childs ALTER COLUMN key SET DEFAULT nextval('group_childs_key_seq'::regclass);


--
-- TOC entry 1885 (class 2604 OID 473497)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY groups ALTER COLUMN key SET DEFAULT nextval('groups_key_seq'::regclass);


--
-- TOC entry 1889 (class 2604 OID 473538)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY linked_account_claims ALTER COLUMN key SET DEFAULT nextval('linked_account_claims_key_seq'::regclass);


--
-- TOC entry 1890 (class 2604 OID 473549)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY linked_accounts ALTER COLUMN key SET DEFAULT nextval('linked_accounts_key_seq'::regclass);


--
-- TOC entry 1891 (class 2604 OID 473560)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY password_reset_secrets ALTER COLUMN key SET DEFAULT nextval('password_reset_secrets_key_seq'::regclass);


--
-- TOC entry 1892 (class 2604 OID 473571)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY two_factor_auth_tokens ALTER COLUMN key SET DEFAULT nextval('two_factor_auth_tokens_key_seq'::regclass);


--
-- TOC entry 1887 (class 2604 OID 473516)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY user_accounts ALTER COLUMN key SET DEFAULT nextval('user_accounts_key_seq'::regclass);


--
-- TOC entry 1893 (class 2604 OID 473582)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY user_certificates ALTER COLUMN key SET DEFAULT nextval('user_certificates_key_seq'::regclass);


--
-- TOC entry 1888 (class 2604 OID 473527)
-- Name: key; Type: DEFAULT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY user_claims ALTER COLUMN key SET DEFAULT nextval('user_claims_key_seq'::regclass);


--
-- TOC entry 2036 (class 0 OID 473505)
-- Dependencies: 175
-- Data for Name: group_childs; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY group_childs (key, parent_key, child_group_id) FROM stdin;
\.


--
-- TOC entry 2064 (class 0 OID 0)
-- Dependencies: 174
-- Name: group_childs_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('group_childs_key_seq', 1, false);


--
-- TOC entry 2034 (class 0 OID 473494)
-- Dependencies: 173
-- Data for Name: groups; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY groups (key, id, tenant, name, created, last_updated) FROM stdin;
\.


--
-- TOC entry 2065 (class 0 OID 0)
-- Dependencies: 172
-- Name: groups_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('groups_key_seq', 1, false);


--
-- TOC entry 2042 (class 0 OID 473535)
-- Dependencies: 181
-- Data for Name: linked_account_claims; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY linked_account_claims (key, parent_key, provider_name, provider_account_id, type_t, value) FROM stdin;
\.


--
-- TOC entry 2066 (class 0 OID 0)
-- Dependencies: 180
-- Name: linked_account_claims_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('linked_account_claims_key_seq', 1, false);


--
-- TOC entry 2044 (class 0 OID 473546)
-- Dependencies: 183
-- Data for Name: linked_accounts; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY linked_accounts (key, parent_key, provider_name, provider_account_id, last_login) FROM stdin;
\.


--
-- TOC entry 2067 (class 0 OID 0)
-- Dependencies: 182
-- Name: linked_accounts_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('linked_accounts_key_seq', 1, false);


--
-- TOC entry 2046 (class 0 OID 473557)
-- Dependencies: 185
-- Data for Name: password_reset_secrets; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY password_reset_secrets (key, parent_key, password_reset_secret_id, question, answer) FROM stdin;
\.


--
-- TOC entry 2068 (class 0 OID 0)
-- Dependencies: 184
-- Name: password_reset_secrets_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('password_reset_secrets_key_seq', 1, false);


--
-- TOC entry 2048 (class 0 OID 473568)
-- Dependencies: 187
-- Data for Name: two_factor_auth_tokens; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY two_factor_auth_tokens (key, parent_key, token, issued) FROM stdin;
\.


--
-- TOC entry 2069 (class 0 OID 0)
-- Dependencies: 186
-- Name: two_factor_auth_tokens_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('two_factor_auth_tokens_key_seq', 1, false);


--
-- TOC entry 2038 (class 0 OID 473513)
-- Dependencies: 177
-- Data for Name: user_accounts; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY user_accounts (key, id, tenant, username, created, last_updated, is_account_closed, account_closed, is_login_allowed, last_login, last_failed_login, failed_login_count, password_changed, requires_password_reset, email, is_account_verified, last_failed_password_reset, failed_password_reset_count, mobile_code, mobile_code_sent, mobile_phone_number, mobile_phone_number_changed, account_two_factor_auth_mode, current_two_factor_auth_status, verification_key, verification_purpose, verification_key_sent, verification_storage, hashed_password) FROM stdin;
\.


--
-- TOC entry 2070 (class 0 OID 0)
-- Dependencies: 176
-- Name: user_accounts_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('user_accounts_key_seq', 1, false);


--
-- TOC entry 2050 (class 0 OID 473579)
-- Dependencies: 189
-- Data for Name: user_certificates; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY user_certificates (key, parent_key, thumbprint, subject) FROM stdin;
\.


--
-- TOC entry 2071 (class 0 OID 0)
-- Dependencies: 188
-- Name: user_certificates_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('user_certificates_key_seq', 1, false);


--
-- TOC entry 2040 (class 0 OID 473524)
-- Dependencies: 179
-- Data for Name: user_claims; Type: TABLE DATA; Schema: membership_reboot; Owner: postgres
--

COPY user_claims (key, parent_key, type_t, value) FROM stdin;
\.


--
-- TOC entry 2072 (class 0 OID 0)
-- Dependencies: 178
-- Name: user_claims_key_seq; Type: SEQUENCE SET; Schema: membership_reboot; Owner: postgres
--

SELECT pg_catalog.setval('user_claims_key_seq', 1, false);


--
-- TOC entry 1898 (class 2606 OID 473510)
-- Name: PK_membership_reboot.group_childs; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY group_childs
    ADD CONSTRAINT "PK_membership_reboot.group_childs" PRIMARY KEY (key);


--
-- TOC entry 1895 (class 2606 OID 473502)
-- Name: PK_membership_reboot.groups; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY groups
    ADD CONSTRAINT "PK_membership_reboot.groups" PRIMARY KEY (key);


--
-- TOC entry 1906 (class 2606 OID 473543)
-- Name: PK_membership_reboot.linked_account_claims; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY linked_account_claims
    ADD CONSTRAINT "PK_membership_reboot.linked_account_claims" PRIMARY KEY (key);


--
-- TOC entry 1909 (class 2606 OID 473554)
-- Name: PK_membership_reboot.linked_accounts; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY linked_accounts
    ADD CONSTRAINT "PK_membership_reboot.linked_accounts" PRIMARY KEY (key);


--
-- TOC entry 1912 (class 2606 OID 473565)
-- Name: PK_membership_reboot.password_reset_secrets; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY password_reset_secrets
    ADD CONSTRAINT "PK_membership_reboot.password_reset_secrets" PRIMARY KEY (key);


--
-- TOC entry 1915 (class 2606 OID 473576)
-- Name: PK_membership_reboot.two_factor_auth_tokens; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY two_factor_auth_tokens
    ADD CONSTRAINT "PK_membership_reboot.two_factor_auth_tokens" PRIMARY KEY (key);


--
-- TOC entry 1900 (class 2606 OID 473521)
-- Name: PK_membership_reboot.user_accounts; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY user_accounts
    ADD CONSTRAINT "PK_membership_reboot.user_accounts" PRIMARY KEY (key);


--
-- TOC entry 1918 (class 2606 OID 473587)
-- Name: PK_membership_reboot.user_certificates; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY user_certificates
    ADD CONSTRAINT "PK_membership_reboot.user_certificates" PRIMARY KEY (key);


--
-- TOC entry 1903 (class 2606 OID 473532)
-- Name: PK_membership_reboot.user_claims; Type: CONSTRAINT; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY user_claims
    ADD CONSTRAINT "PK_membership_reboot.user_claims" PRIMARY KEY (key);


--
-- TOC entry 1896 (class 1259 OID 473588)
-- Name: IX_membership_reboot.group_childs_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.group_childs_parent_key" ON group_childs USING btree (parent_key);


--
-- TOC entry 1904 (class 1259 OID 473590)
-- Name: IX_membership_reboot.linked_account_claims_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.linked_account_claims_parent_key" ON linked_account_claims USING btree (parent_key);


--
-- TOC entry 1907 (class 1259 OID 473591)
-- Name: IX_membership_reboot.linked_accounts_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.linked_accounts_parent_key" ON linked_accounts USING btree (parent_key);


--
-- TOC entry 1910 (class 1259 OID 473592)
-- Name: IX_membership_reboot.password_reset_secrets_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.password_reset_secrets_parent_key" ON password_reset_secrets USING btree (parent_key);


--
-- TOC entry 1913 (class 1259 OID 473593)
-- Name: IX_membership_reboot.two_factor_auth_tokens_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.two_factor_auth_tokens_parent_key" ON two_factor_auth_tokens USING btree (parent_key);


--
-- TOC entry 1916 (class 1259 OID 473594)
-- Name: IX_membership_reboot.user_certificates_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.user_certificates_parent_key" ON user_certificates USING btree (parent_key);


--
-- TOC entry 1901 (class 1259 OID 473589)
-- Name: IX_membership_reboot.user_claims_parent_key; Type: INDEX; Schema: membership_reboot; Owner: postgres; Tablespace: 
--

CREATE INDEX "IX_membership_reboot.user_claims_parent_key" ON user_claims USING btree (parent_key);


--
-- TOC entry 1919 (class 2606 OID 473595)
-- Name: FK_membership_reboot.group_childs_membership_reboot.groups_pare; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY group_childs
    ADD CONSTRAINT "FK_membership_reboot.group_childs_membership_reboot.groups_pare" FOREIGN KEY (parent_key) REFERENCES groups(key) ON DELETE CASCADE;


--
-- TOC entry 1921 (class 2606 OID 473605)
-- Name: FK_membership_reboot.linked_account_claims_membership_reboot.us; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY linked_account_claims
    ADD CONSTRAINT "FK_membership_reboot.linked_account_claims_membership_reboot.us" FOREIGN KEY (parent_key) REFERENCES user_accounts(key) ON DELETE CASCADE;


--
-- TOC entry 1922 (class 2606 OID 473610)
-- Name: FK_membership_reboot.linked_accounts_membership_reboot.user_acc; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY linked_accounts
    ADD CONSTRAINT "FK_membership_reboot.linked_accounts_membership_reboot.user_acc" FOREIGN KEY (parent_key) REFERENCES user_accounts(key) ON DELETE CASCADE;


--
-- TOC entry 1923 (class 2606 OID 473615)
-- Name: FK_membership_reboot.password_reset_secrets_membership_reboot.u; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY password_reset_secrets
    ADD CONSTRAINT "FK_membership_reboot.password_reset_secrets_membership_reboot.u" FOREIGN KEY (parent_key) REFERENCES user_accounts(key) ON DELETE CASCADE;


--
-- TOC entry 1924 (class 2606 OID 473620)
-- Name: FK_membership_reboot.two_factor_auth_tokens_membership_reboot.u; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY two_factor_auth_tokens
    ADD CONSTRAINT "FK_membership_reboot.two_factor_auth_tokens_membership_reboot.u" FOREIGN KEY (parent_key) REFERENCES user_accounts(key) ON DELETE CASCADE;


--
-- TOC entry 1925 (class 2606 OID 473625)
-- Name: FK_membership_reboot.user_certificates_membership_reboot.user_a; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY user_certificates
    ADD CONSTRAINT "FK_membership_reboot.user_certificates_membership_reboot.user_a" FOREIGN KEY (parent_key) REFERENCES user_accounts(key) ON DELETE CASCADE;


--
-- TOC entry 1920 (class 2606 OID 473600)
-- Name: FK_membership_reboot.user_claims_membership_reboot.user_account; Type: FK CONSTRAINT; Schema: membership_reboot; Owner: postgres
--

ALTER TABLE ONLY user_claims
    ADD CONSTRAINT "FK_membership_reboot.user_claims_membership_reboot.user_account" FOREIGN KEY (parent_key) REFERENCES user_accounts(key) ON DELETE CASCADE;


-- Completed on 2014-08-06 01:12:12

--
-- PostgreSQL database dump complete
--

