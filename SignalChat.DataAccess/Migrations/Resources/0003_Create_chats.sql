create table if not exists chats
(
    id         serial primary key,
    name       text,
    creator_id int references users (id)
);

create index chat_id_index on chats (id);