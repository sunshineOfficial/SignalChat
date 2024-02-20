insert into users (username, email, name, surname, password_hash, refresh_token, refresh_token_expired_after)
values (@Username, @Email, @Name, @Surname, @PasswordHash, @RefreshToken, @RefreshTokenExpiredAfter)
returning id;