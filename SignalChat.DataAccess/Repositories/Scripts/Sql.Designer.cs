﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignalChat.DataAccess.Repositories.Scripts {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Sql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SignalChat.DataAccess.Repositories.Scripts.Sql", typeof(Sql).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update users
        ///set password_hash = @passwordHash
        ///where id = @id;.
        /// </summary>
        internal static string ChangePassword {
            get {
                return ResourceManager.GetString("ChangePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into chats (name, creator_id)
        ///values (@Name, @CreatorId)
        ///returning id;.
        /// </summary>
        internal static string CreateChat {
            get {
                return ResourceManager.GetString("CreateChat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into chat_participants (user_id, chat_id, role)
        ///values (@UserId, @ChatId, @Role);.
        /// </summary>
        internal static string CreateChatParticipant {
            get {
                return ResourceManager.GetString("CreateChatParticipant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into messages (text, sent_on, chat_id, user_id)
        ///values (@Text, @SentOn, @ChatId, @UserId)
        ///returning id;.
        /// </summary>
        internal static string CreateMessage {
            get {
                return ResourceManager.GetString("CreateMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into users (role, username, email, name, surname, password_hash, refresh_token, refresh_token_expired_after)
        ///values (@Role, @Username, @Email, @Name, @Surname, @PasswordHash, @RefreshToken, @RefreshTokenExpiredAfter)
        ///returning id;.
        /// </summary>
        internal static string CreateUser {
            get {
                return ResourceManager.GetString("CreateUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete
        ///from users
        ///where id = @id;.
        /// </summary>
        internal static string DeleteUser {
            get {
                return ResourceManager.GetString("DeleteUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update messages
        ///set text      = @editedText,
        ///    edited_on = @editedOn
        ///where id = @id;.
        /// </summary>
        internal static string EditMessage {
            get {
                return ResourceManager.GetString("EditMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id         as Id,
        ///       name       as Name,
        ///       creator_id as CreatorId
        ///from chats
        ///where id = @id;.
        /// </summary>
        internal static string GetChatById {
            get {
                return ResourceManager.GetString("GetChatById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select u.id       as UserId,
        ///       u.username as Username,
        ///       u.name     as Name,
        ///       u.surname  as Surname,
        ///       cp.chat_id as ChatId,
        ///       cp.role    as Role
        ///from chat_participants cp
        ///         join users u on cp.user_id = u.id
        ///where cp.user_id = @userId
        ///  and cp.chat_id = @chatId;.
        /// </summary>
        internal static string GetChatParticipantFull {
            get {
                return ResourceManager.GetString("GetChatParticipantFull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select user_id as UserId,
        ///       chat_id as ChatId,
        ///       role    as Role
        ///from chat_participants
        ///where chat_id = @chatId;.
        /// </summary>
        internal static string GetChatParticipantsByChatId {
            get {
                return ResourceManager.GetString("GetChatParticipantsByChatId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select user_id as UserId,
        ///       chat_id as ChatId,
        ///       role    as Role
        ///from chat_participants
        ///where user_id = @userId;.
        /// </summary>
        internal static string GetChatParticipantsByUserId {
            get {
                return ResourceManager.GetString("GetChatParticipantsByUserId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select u.id       as UserId,
        ///       u.username as Username,
        ///       u.name     as Name,
        ///       u.surname  as Surname,
        ///       cp.chat_id as ChatId,
        ///       cp.role    as Role
        ///from chat_participants cp
        ///         join users u on cp.user_id = u.id
        ///where cp.chat_id = @chatId;.
        /// </summary>
        internal static string GetChatParticipantsFullByChatId {
            get {
                return ResourceManager.GetString("GetChatParticipantsFullByChatId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select c.id         as Id,
        ///       c.name       as Name,
        ///       c.creator_id as CreatorId
        ///from chats c
        ///         join chat_participants cp on c.id = cp.chat_id
        ///where cp.user_id = @userId;.
        /// </summary>
        internal static string GetChatsByUserId {
            get {
                return ResourceManager.GetString("GetChatsByUserId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id        as Id,
        ///       text      as Text,
        ///       sent_on   as SentOn,
        ///       chat_id   as ChatId,
        ///       user_id   as UserId,
        ///       edited_on as EditedOn
        ///from messages
        ///where id = @id;.
        /// </summary>
        internal static string GetMessageById {
            get {
                return ResourceManager.GetString("GetMessageById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id        as Id,
        ///       text      as Text,
        ///       sent_on   as SentOn,
        ///       chat_id   as ChatId,
        ///       user_id   as UserId,
        ///       edited_on as EditedOn
        ///from messages
        ///where chat_id = @chatId
        ///  and sent_on &gt;= @from
        ///order by sent_on;.
        /// </summary>
        internal static string GetMessagesByChat {
            get {
                return ResourceManager.GetString("GetMessagesByChat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users
        ///where id = @id;.
        /// </summary>
        internal static string GetUserById {
            get {
                return ResourceManager.GetString("GetUserById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users
        ///where (email = @login or username = @login)
        ///  and pas [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetUserByLoginAndPassword {
            get {
                return ResourceManager.GetString("GetUserByLoginAndPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users
        ///where refresh_token = @refreshToken;.
        /// </summary>
        internal static string GetUserByRefreshToken {
            get {
                return ResourceManager.GetString("GetUserByRefreshToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users;.
        /// </summary>
        internal static string GetUsers {
            get {
                return ResourceManager.GetString("GetUsers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select exists(select id
        ///              from chats
        ///              where id = @id);.
        /// </summary>
        internal static string IsChatExists {
            get {
                return ResourceManager.GetString("IsChatExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select exists(select user_id
        ///              from chat_participants
        ///              where user_id = @userId
        ///                and chat_id = @chatId);.
        /// </summary>
        internal static string IsChatParticipantExists {
            get {
                return ResourceManager.GetString("IsChatParticipantExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select exists(select id
        ///              from messages
        ///              where id = @id);.
        /// </summary>
        internal static string IsMessageExists {
            get {
                return ResourceManager.GetString("IsMessageExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select exists(select id
        ///              from users
        ///              where email = @email);.
        /// </summary>
        internal static string IsUserExistsByEmail {
            get {
                return ResourceManager.GetString("IsUserExistsByEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select exists(select id
        ///              from users
        ///              where id = @id);.
        /// </summary>
        internal static string IsUserExistsById {
            get {
                return ResourceManager.GetString("IsUserExistsById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select exists(select id
        ///              from users
        ///              where username = @username);.
        /// </summary>
        internal static string IsUserExistsByUsername {
            get {
                return ResourceManager.GetString("IsUserExistsByUsername", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update users
        ///set refresh_token               = @refreshToken,
        ///    refresh_token_expired_after = @refreshTokenExpiredAfter
        ///where id = @Id;.
        /// </summary>
        internal static string UpdateRefreshToken {
            get {
                return ResourceManager.GetString("UpdateRefreshToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update users
        ///set username = coalesce(@Username, username),
        ///    email    = coalesce(@Email, email),
        ///    name     = coalesce(@Name, name),
        ///    surname  = coalesce(@Surname, surname)
        ///where id = @Id;.
        /// </summary>
        internal static string UpdateUser {
            get {
                return ResourceManager.GetString("UpdateUser", resourceCulture);
            }
        }
    }
}
