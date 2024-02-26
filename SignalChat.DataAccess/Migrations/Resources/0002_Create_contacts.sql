create table if not exists contacts
(
    user_id   int references users (id),
    friend_id int references users (id)
);