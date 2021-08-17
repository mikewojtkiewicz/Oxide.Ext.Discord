using System.Runtime.Serialization;

namespace Oxide.Ext.Discord.Entities.Teams
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/teams#data-models-membership-state-enum">Membership State Enum</a>
    /// </summary>
    public enum TeamMembershipState
    {
        /// <summary>
        /// If the user has been invited
        /// </summary>
        [EnumMember(Value = "INVITED")]
        Invited = 1,
        
        /// <summary>
        /// If the is part of the team
        /// </summary>
        [EnumMember(Value = "ACCEPTED")]
        Accepted = 2
    }
}