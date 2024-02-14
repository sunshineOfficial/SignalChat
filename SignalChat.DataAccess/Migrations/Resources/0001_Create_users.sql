create table if not exists users
(
    id            integer primary key generated always as identity,
    username      text unique not null,
    email         text unique not null,
    name          text,
    surname       text,
    password_hash text
);

create index user_id_index on users (id);
create index username_index on users (username);
create index email_index on users (email);