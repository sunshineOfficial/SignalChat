select exists(select id
              from users
              where username = @username);