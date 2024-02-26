create table if not exists users
(
    id                          serial primary key,
    role                        int         not null default 0,
    username                    text unique not null,
    email                       text unique not null,
    name                        text,
    surname                     text,
    password_hash               text,
    refresh_token               text,
    refresh_token_expired_after timestamp
);

create index user_id_index on users (id);
create index username_index on users (username);
create index email_index on users (email);