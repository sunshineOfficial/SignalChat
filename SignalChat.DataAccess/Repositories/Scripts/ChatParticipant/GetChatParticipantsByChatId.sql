select user_id as UserId,
       chat_id as ChatId,
       role    as Role
from chat_participants
where chat_id = @chatId;