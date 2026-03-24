namespace AngbandOS.Core.Interface;

public class GameReplayDetails
{
    public int Seed { get; }
    public GameReplayStep[] GameReplaySteps { get; }

    public GameReplayDetails(int seed, GameReplayStep[] gameReplaySteps)
    {
        Seed = seed;
        GameReplaySteps = gameReplaySteps;
    }
}
