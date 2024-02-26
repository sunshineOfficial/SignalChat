insert into users (role, username, email, name, surname, password_hash, refresh_token, refresh_token_expired_after)
values (@Role, @Username, @Email, @Name, @Surname, @PasswordHash, @RefreshToken, @RefreshTokenExpiredAfter)
returning id;