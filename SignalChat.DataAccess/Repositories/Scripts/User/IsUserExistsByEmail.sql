select exists(select id
              from users
              where email = @email);