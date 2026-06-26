namespace AngbandOS.Core.Interface;

public class GameReplayStep
{
    public DateTimeOffset DateTime { get; }
    public char Keystroke { get; }
    public int Seed { get; }
    public string? StackTrace { get; }

    public GameReplayStep(DateTimeOffset dateTime, char keystroke, int seed, string? stackTrace)
    {
        DateTime = dateTime;
        Keystroke = keystroke;
        Seed = seed;
        StackTrace = stackTrace;
    }
}
