select exists(select id
              from users
              where id = @id);