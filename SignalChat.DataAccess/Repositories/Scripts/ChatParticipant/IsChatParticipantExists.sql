select exists(select user_id
              from chat_participants
              where user_id = @userId
                and chat_id = @chatId);