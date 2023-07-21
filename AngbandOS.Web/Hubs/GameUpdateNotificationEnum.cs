namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents various events received from the game.  These enumerations are sent from the SignalRConsole to the GameService so that the GameService can
    /// either update the client or log messages to the database.
    /// </summary>
    public enum GameUpdateNotificationEnum
    {
        /// <summary>
        /// Represents an event received from the game that the players' gold level has changed.
        /// </summary>
        GoldUpdated = 0,

        /// <summary>
        /// Represents an event received from the game that the players' dungeon level has changed.
        /// </summary>
        ExperienceLevelChanged = 1,

        /// <summary>
        /// Represents an event received from the game that the players' characters' name has changed.
        /// </summary>
        CharacterRenamed = 2,

        /// <summary>
        /// Represents an event received from the game that the player has died.
        /// </summary>
        PlayerDied = 3,

        /// <summary>
        /// Represents an event received that the game started.
        /// </summary>
        GameStarted = 4,

        /// <summary>
        /// Represents an event received that the game stopped.
        /// </summary>
        GameStopped = 5,

        /// <summary>
        /// Represents an event received that an exception was thrown during the game.
        /// </summary>
        GameExceptionThrown = 6,

        /// <summary>
        /// Represents an event received that the game time changed.
        /// </summary>
        GameTimeElapsed = 7,

        /// <summary>
        /// Represents an event received that input from the player has been received and processed by the game.
        /// </summary>
        InputReceived = 8
    }
}
