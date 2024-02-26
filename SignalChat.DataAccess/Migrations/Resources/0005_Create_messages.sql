create table if not exists messages
(
    id      serial primary key,
    text    text,
    sent_on timestamp,
    chat_id int references chats (id),
    user_id int references users (id)
);