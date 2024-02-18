update users
set refresh_token               = @refreshToken,
    refresh_token_expired_after = @refreshTokenExpiredAfter
where id = @Id;