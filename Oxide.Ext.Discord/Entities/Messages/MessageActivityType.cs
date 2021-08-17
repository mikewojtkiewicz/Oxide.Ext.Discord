using System.ComponentModel;
using System.Runtime.Serialization;

namespace Oxide.Ext.Discord.Entities.Messages
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-object-message-activity-types">Message Activity Types</a>
    /// </summary>
    public enum MessageActivityType
    {
        /// <summary>
        /// Message Activity Join
        /// </summary>
        [EnumMember(Value = "JOIN")]
        Join = 1,
        
        /// <summary>
        /// Message Activity Spectate
        /// </summary>
        [EnumMember(Value = "SPECTATE")]
        Spectate = 2,
        
        /// <summary>
        /// Message Activity Listen
        /// </summary>
        [EnumMember(Value = "LISTEN")]
        Listen = 3,
        
        /// <summary>
        /// Message Activity JoinRequest
        /// </summary>
        [EnumMember(Value = "JOIN_REQUEST")]
        JoinRequest = 5,
    }
}