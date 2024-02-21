insert into messages (text, sent_on, chat_id, user_id)
values (@Text, @SentOn, @ChatId, @UserId)
returning id;