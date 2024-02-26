create table if not exists chat_participants
(
    user_id int references users (id),
    chat_id int references chats (id),
    role    int default 0
);