// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface;

public class InvalidStepSeedReplayVerificationFailureException : ReplayVerificationFailureException
{
    public readonly int ActualStepSeed;
    public readonly int ExpectedStepSeed;
    public readonly char Keystroke;
    public readonly DateTimeOffset ReplayDateTime;
    public readonly int RemainingQueueCount;

    public InvalidStepSeedReplayVerificationFailureException(int actualStepSeed, int expectedStepSeed, char keystroke, DateTimeOffset replayDateTime, int remainingQueueCount)
    {
        ActualStepSeed = actualStepSeed;
        ExpectedStepSeed = expectedStepSeed;
        Keystroke = keystroke;
        ReplayDateTime = replayDateTime;
        RemainingQueueCount = remainingQueueCount;
    }

    public override string Message => $"Replay verification failure: Current random seed {ActualStepSeed} does not match expected random seed {ExpectedStepSeed} for replay step with keystroke {Keystroke} at {ReplayDateTime} with {RemainingQueueCount} steps remaining in the queue.";
}