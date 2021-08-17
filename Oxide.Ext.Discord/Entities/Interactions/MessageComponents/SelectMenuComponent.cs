using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.Interactions.MessageComponents
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-menus">Select Menus Component</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SelectMenuComponent : BaseComponent
    {
        /// <summary>
        /// A developer-defined identifier for the button
        /// Max 100 characters
        /// </summary>
        [JsonProperty("custom_id")]
        public string CustomId { get; set; }

        /// <summary>
        /// The choices in the select
        /// Max 25 options
        /// </summary>
        [JsonProperty("custom_id")]
        public List<SelectMenuOption> Options { get; private set; } = new List<SelectMenuOption>();
        
        /// <summary>
        /// Custom placeholder text if nothing is selected
        /// Max 100 characters
        /// </summary>
        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }

        /// <summary>
        /// the minimum number of items that must be chosen;
        /// Default 1, Min 0, Max 25
        /// </summary>
        [JsonProperty("min_values")]
        public int? MinValues { get; set; }
        
        /// <summary>
        /// the maximum  number of items that must be chosen;
        /// Default 1, Min 0, Max 25
        /// </summary>
        [JsonProperty("max_values")]
        public int? MaxValues { get; set; }
        
        /// <summary>
        /// Disable the select
        /// Default false
        /// </summary>
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
        
        /// <summary>
        /// Select Menu Component Constructor
        /// </summary>
        public SelectMenuComponent()
        {
            Type = MessageComponentType.SelectMenu;
        }

        /// <summary>
        /// Adds an option to a select menu;
        /// </summary>
        /// <param name="option"></param>
        /// <exception cref="Exception"></exception>
        public SelectMenuComponent AddOption(SelectMenuOption option)
        {
            if (Options.Count >= 25)
            {
                throw new Exception("Select Menu Options cannot have more than 25 options");
            }
            
            Options.Add(option);
            return this;
        }
    }
}