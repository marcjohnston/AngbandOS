// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GameReplay
{
    public int MainSequenceRandomSeed { get; }
    public GameReplayStep[] GameReplaySteps { get; }

    public GameReplay(int mainSequenceRandomSeed, GameReplayStep[] gameReplaySteps)
    {
        MainSequenceRandomSeed = mainSequenceRandomSeed;
        GameReplaySteps = gameReplaySteps;
    }
}
