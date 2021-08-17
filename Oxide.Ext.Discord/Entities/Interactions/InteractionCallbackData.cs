using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Interactions.MessageComponents;
using Oxide.Ext.Discord.Entities.Messages;
using Oxide.Ext.Discord.Entities.Messages.Embeds;

namespace Oxide.Ext.Discord.Entities.Interactions
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-response-object-interaction-callback-data-structure">Interaction Application Command Callback Data Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionCallbackData
    {
        /// <summary>
        /// Is the response TTS
        /// </summary>
        [JsonProperty("tts")]
        public bool? Tts { get; set; } 
        
        /// <summary>
        /// Message content
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } 
        
        /// <summary>
        /// List of embeds
        /// Supports up to 10 embedsF
        /// </summary>
        [JsonProperty("embeds")]
        public List<DiscordEmbed> Embeds { get; set; } 
        
        /// <summary>
        /// Allowed mentions 
        /// </summary>
        [JsonProperty("allowed_mentions")]
        public bool AllowedMentions { get; set; }
        
        /// <summary>
        /// Callback data flags
        /// </summary>
        [JsonProperty("flags")]
        public MessageFlags? Flags { get; set; }
        
        /// <summary>
        /// Message components 
        /// </summary>
        [JsonProperty("components")]
        public List<ActionRowComponent> Components { get; set; }
    }
}