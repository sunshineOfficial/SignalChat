update users
set password_hash = @passwordHash
where id = @id;