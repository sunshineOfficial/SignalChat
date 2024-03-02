select id         as Id,
       name       as Name,
       creator_id as CreatorId
from chats
where id = @id;