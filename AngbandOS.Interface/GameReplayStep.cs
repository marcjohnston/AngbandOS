namespace AngbandOS.Core.Interface;

public class GameReplayStep
{
    public DateTime DateTime { get; }
    public char Keystroke { get; }
    public int? Seed { get; }

    public GameReplayStep(DateTime dateTime, char keystroke, int? seed)
    {
        DateTime = dateTime;
        Keystroke = keystroke;
        Seed = seed;
    }
}
