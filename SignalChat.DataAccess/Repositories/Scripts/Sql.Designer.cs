﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignalChat.DataAccess.Repositories.Scripts {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Sql {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("SignalChat.DataAccess.Repositories.Scripts.Sql", typeof(Sql).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string CreateChat {
            get {
                return ResourceManager.GetString("CreateChat", resourceCulture);
            }
        }
        
        internal static string IsChatExists {
            get {
                return ResourceManager.GetString("IsChatExists", resourceCulture);
            }
        }
        
        internal static string CreateChatParticipant {
            get {
                return ResourceManager.GetString("CreateChatParticipant", resourceCulture);
            }
        }
        
        internal static string IsChatParticipantExists {
            get {
                return ResourceManager.GetString("IsChatParticipantExists", resourceCulture);
            }
        }
        
        internal static string GetChatParticipantsByUserId {
            get {
                return ResourceManager.GetString("GetChatParticipantsByUserId", resourceCulture);
            }
        }
        
        internal static string CreateMessage {
            get {
                return ResourceManager.GetString("CreateMessage", resourceCulture);
            }
        }
        
        internal static string GetMessagesByChat {
            get {
                return ResourceManager.GetString("GetMessagesByChat", resourceCulture);
            }
        }
        
        internal static string CreateUser {
            get {
                return ResourceManager.GetString("CreateUser", resourceCulture);
            }
        }
        
        internal static string DeleteUser {
            get {
                return ResourceManager.GetString("DeleteUser", resourceCulture);
            }
        }
        
        internal static string GetUserByLoginAndPassword {
            get {
                return ResourceManager.GetString("GetUserByLoginAndPassword", resourceCulture);
            }
        }
        
        internal static string GetUserById {
            get {
                return ResourceManager.GetString("GetUserById", resourceCulture);
            }
        }
        
        internal static string GetUserByRefreshToken {
            get {
                return ResourceManager.GetString("GetUserByRefreshToken", resourceCulture);
            }
        }
        
        internal static string GetUsers {
            get {
                return ResourceManager.GetString("GetUsers", resourceCulture);
            }
        }
        
        internal static string IsUserExistsByEmail {
            get {
                return ResourceManager.GetString("IsUserExistsByEmail", resourceCulture);
            }
        }
        
        internal static string IsUserExistsById {
            get {
                return ResourceManager.GetString("IsUserExistsById", resourceCulture);
            }
        }
        
        internal static string IsUserExistsByUsername {
            get {
                return ResourceManager.GetString("IsUserExistsByUsername", resourceCulture);
            }
        }
        
        internal static string UpdateRefreshToken {
            get {
                return ResourceManager.GetString("UpdateRefreshToken", resourceCulture);
            }
        }
        
        internal static string UpdateUser {
            get {
                return ResourceManager.GetString("UpdateUser", resourceCulture);
            }
        }
    }
}
