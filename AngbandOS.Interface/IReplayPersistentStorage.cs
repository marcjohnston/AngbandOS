namespace AngbandOS.Core.Interface;

public interface IReplayPersistentStorage
{
    /// <summary>
    /// Called for each step of the game, to allow the persistent storage to record the given keystroke at the given date and time.  The date and time are provided to allow the persistent storage to determine if a significant amount of time has passed between steps, which may indicate that the player has taken a break from playing the game.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="keystroke"></param>
    void WriteStep(DateTime dateTime, char keystroke);

    /// <summary>
    /// Called when a new game is started, to allow the persistent storage to clear any existing data and prepare for a new game with the given seed.
    /// </summary>
    /// <param name="seed"></param>
    void NewGame(int seed);

    /// <summary>
    /// Returns the replay details for the game with the given guid.
    /// </summary>
    /// <param name="gameGuid"></param>
    /// <returns></returns>
    GameReplayDetails GetReplay(string gameGuid);
}
