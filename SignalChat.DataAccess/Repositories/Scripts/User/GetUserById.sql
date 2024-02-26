select id                          as Id,
       role                        as Role,
       username                    as Username,
       email                       as Email,
       name                        as Name,
       surname                     as Surname,
       password_hash               as PasswordHash,
       refresh_token               as RefreshToken,
       refresh_token_expired_after as RefreshTokenExpiredAfter
from users
where id = @id;