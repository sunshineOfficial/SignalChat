insert into chats (name, creator_id)
values (@Name, @CreatorId)
returning id;