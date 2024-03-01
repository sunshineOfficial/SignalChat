select c.id         as Id,
       c.name       as Name,
       c.creator_id as CreatorId
from chats c
         join chat_participants cp on c.id = cp.chat_id
where cp.user_id = @userId;