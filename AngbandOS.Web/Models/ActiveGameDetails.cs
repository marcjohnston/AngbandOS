namespace AngbandOS.Web.Models
{
    public class ActiveGameDetails
    {
        /// <summary>
        /// Returns the username of the game owner.  This is rendered in the home screen active games list.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Returns the unique identifier for the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Returns the signal-r connection ID for the game.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Returns the current level of the player or null, if the player is dead.
        /// </summary>
        public int? Level { get; set; }

        /// <summary>
        /// Returns the current amount of gold the player has or null, if the player is dead.
        /// </summary>
        public int? Gold { get; set; }

        /// <summary>
        /// Returns the character name of the player or null, if the player is dead.
        /// </summary>
        public string? CharacterName { get; set; }
    }
}
