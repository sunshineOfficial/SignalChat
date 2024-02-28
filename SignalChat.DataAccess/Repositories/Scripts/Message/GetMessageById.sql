select id        as Id,
       text      as Text,
       sent_on   as SentOn,
       chat_id   as ChatId,
       user_id   as UserId,
       edited_on as EditedOn
from messages
where id = @id;