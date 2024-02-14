create table if not exists contacts
(
    user_id   integer references users (id),
    friend_id integer references users (id)
);