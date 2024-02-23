select id      as Id,
       text    as Text,
       sent_on as SentOn,
       chat_id as ChatId,
       user_id as UserId
from messages
where chat_id = @chatId
  and sent_on >= @from
order by sent_on;