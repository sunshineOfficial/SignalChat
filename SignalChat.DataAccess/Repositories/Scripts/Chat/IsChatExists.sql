select exists(select id
              from chats
              where id = @id);