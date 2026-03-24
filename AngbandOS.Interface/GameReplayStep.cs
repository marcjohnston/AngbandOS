namespace AngbandOS.Core.Interface;

public class GameReplayStep
{
    public DateTime DateTime { get; }
    public char Keystroke { get; }

    public GameReplayStep(DateTime dateTime, char keystroke)
    {
        DateTime = dateTime;
        Keystroke = keystroke;
    }
}
