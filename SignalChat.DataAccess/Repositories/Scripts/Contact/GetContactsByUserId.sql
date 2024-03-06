select user_id   as UserId,
       friend_id as FriendId
from contacts
where user_id = @userId;