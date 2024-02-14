create table if not exists chats
(
    id         integer primary key generated always as identity,
    name       text,
    creator_id integer references users (id)
);

create index chat_id_index on chats (id);