select user_id as UserId,
       chat_id as ChatId,
       role    as Role
from chat_participants
where user_id = @userId;