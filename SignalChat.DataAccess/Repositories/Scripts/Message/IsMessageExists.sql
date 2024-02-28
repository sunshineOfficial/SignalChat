select exists(select id
              from messages
              where id = @id);