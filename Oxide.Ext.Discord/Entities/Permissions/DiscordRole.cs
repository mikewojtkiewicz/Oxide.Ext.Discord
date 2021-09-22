﻿using Newtonsoft.Json;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities.Permissions
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/permissions#role-object">Role Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordRole : ISnowflakeEntity
    {
        #region Discord Fields
        /// <summary>
        /// Role id
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Role Color
        /// </summary>
        [JsonProperty("color")]
        public DiscordColor Color { get; set; }

        /// <summary>
        /// If this role is pinned in the user listing
        /// </summary>
        [JsonProperty("hoist")]
        public bool? Hoist { get; set; }
        
        /// <summary>
        /// The role's icon image (if the guild has the ROLE_ICONS feature)
        /// </summary>
        [JsonProperty("icon")]
        public bool Icon { get; set; }
        
        /// <summary>
        /// The role's unicode emoji (if the guild has the ROLE_ICONS feature)
        /// </summary>
        [JsonProperty("unicode_emoji")]
        public bool UnicodeEmoji { get; set; }

        /// <summary>
        /// Position of this role
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Role Permissions
        /// </summary>
        [JsonProperty("permissions")]
        public PermissionFlags Permissions { get; set; }

        /// <summary>
        /// Whether this role is managed by an integration
        /// </summary>
        [JsonProperty("managed")]
        public bool Managed { get; set; }

        /// <summary>
        /// Whether this role is mentionable
        /// </summary>
        [JsonProperty("mentionable")]
        public bool Mentionable { get; set; }
        
        /// <summary>
        /// The tags this role has
        /// </summary>
        [JsonProperty("tags")]
        public RoleTags Tags { get; set; }
        
        /// <summary>
        /// Returns a string to mention this role in a message
        /// </summary>
        public string Mention => DiscordFormatting.MentionRole(Id);
        #endregion

        #region Helper Methods
        /// <summary>
        /// Returns if the role has the specified permission
        /// </summary>
        /// <param name="perm">Permission to check for</param>
        /// <returns>Return true if role has permission; false otherwise</returns>
        public bool HasPermission(PermissionFlags perm)
        {
            return (Permissions & perm) == perm;
        }

        /// <summary>
        /// Returns if this role is the booster
        /// </summary>
        /// <returns>True if booster role. False otherwise;</returns>
        public bool IsBoosterRole()
        {
            return Managed && Tags != null && !Tags.BotId.HasValue;
        }
        #endregion

        #region Entity Update
        internal DiscordRole UpdateRole(DiscordRole role)
        {
            DiscordRole previous = (DiscordRole)MemberwiseClone();
            if (role.Name != null)
            {
                Name = role.Name;
            }

            Color = role.Color;
            Hoist = role.Hoist;
            Position = role.Position;
            Permissions = role.Permissions;
            Managed = role.Managed;
            Mentionable = role.Mentionable;

            if (role.Tags != null)
            {
                Tags = role.Tags;
            }

            return previous;
        }
        #endregion
    }
}
