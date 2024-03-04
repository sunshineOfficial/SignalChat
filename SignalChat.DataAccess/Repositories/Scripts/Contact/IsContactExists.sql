select exists(select user_id
              from contacts
              where user_id = @userId
                and friend_id = @friendId);