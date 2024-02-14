create table if not exists chat_participants
(
    user_id integer references users (id),
    chat_id integer references chats (id),
    role    integer default 0
);