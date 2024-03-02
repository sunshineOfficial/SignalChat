select u.id       as UserId,
       u.username as Username,
       u.name     as Name,
       u.surname  as Surname,
       cp.chat_id as ChatId,
       cp.role    as Role
from chat_participants cp
         join users u on cp.user_id = u.id
where cp.chat_id = @chatId;