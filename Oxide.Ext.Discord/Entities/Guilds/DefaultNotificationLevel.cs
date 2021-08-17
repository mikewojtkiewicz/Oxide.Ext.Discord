using System.Runtime.Serialization;

namespace Oxide.Ext.Discord.Entities.Guilds
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object-default-message-notification-level">Default Message Notification Level</a>
    /// </summary>
    public enum DefaultNotificationLevel
    {
        /// <summary>
        /// Notify for all guild messages
        /// </summary>
        [EnumMember(Value = "ALL_MESSAGES")]
        AllMessages = 0,
        
        /// <summary>
        /// Notify for only mentions
        /// </summary>
        [EnumMember(Value = "ONLY_MENTIONS")]
        OnlyMentions = 1
    }
}