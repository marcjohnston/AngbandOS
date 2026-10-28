namespace AngbandOS.Core.Interface;

public class GameReplayStep
{
    public DateTime DateTime { get; } // 8-bytes
    public char Keystroke { get; } // 2-bytes
    public int Seed { get; } // 4-bytes

    public GameReplayStep(DateTime dateTime, char keystroke, int seed)
    {
        DateTime = dateTime;
        Keystroke = keystroke;
        Seed = seed;
    }
}
