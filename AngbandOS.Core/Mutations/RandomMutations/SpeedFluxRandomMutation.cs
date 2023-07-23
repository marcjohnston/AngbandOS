// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class SpeedFluxRandomMutation : Mutation
{
    private SpeedFluxRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 2;
    public override string GainMessage => "You have become unstuck in time.";
    public override string HaveMessage => "You move faster or slower randomly.";
    public override string LoseMessage => "You are firmly anchored in time.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(6000) == 1)
        {
            saveGame.Disturb(false);
            if (Program.Rng.DieRoll(2) == 1)
            {
                saveGame.MsgPrint("Everything around you speeds up.");
                if (saveGame.TimedHaste.TurnsRemaining > 0)
                {
                    saveGame.TimedHaste.ResetTimer();
                }
                else
                {
                    saveGame.TimedSlow.AddTimer(Program.Rng.DieRoll(30) + 10);
                }
            }
            else
            {
                saveGame.MsgPrint("Everything around you slows down.");
                if (saveGame.TimedSlow.TurnsRemaining > 0)
                {
                    saveGame.TimedSlow.ResetTimer();
                }
                else
                {
                    saveGame.TimedHaste.AddTimer(Program.Rng.DieRoll(30) + 10);
                }
            }
            saveGame.MsgPrint(null);
        }
    }
}