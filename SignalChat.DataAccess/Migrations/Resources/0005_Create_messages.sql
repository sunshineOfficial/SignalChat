create table if not exists messages
(
    id      integer primary key generated always as identity,
    text    text,
    sent_on timestamp,
    chat_id integer references chats (id),
    user_id integer references users (id)
);