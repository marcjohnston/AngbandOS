// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AlcoholRandomMutation : Mutation
{
    public override int Frequency => 1;
    public override string GainMessage => "Your body starts producing alcohol!";
    public override string HaveMessage => "Your body produces alcohol.";
    public override string LoseMessage => "Your body stops producing alcohol!";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(6400) != 321)
        {
            return;
        }
        if (saveGame.HasChaosResistance && saveGame.HasConfusionResistance)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.PrExtraRedrawAction.Set();
        saveGame.MsgPrint("You feel a SSSCHtupor cOmINg over yOu... *HIC*!");
        if (Program.Rng.DieRoll(20) == 1)
        {
            saveGame.MsgPrint(null);
            if (Program.Rng.DieRoll(3) == 1)
            {
                saveGame.LoseAllInfo();
            }
            else
            {
                saveGame.WizDark();
            }
            saveGame.TeleportPlayer(100);
            saveGame.WizDark();
            saveGame.MsgPrint("You wake up somewhere with a sore head...");
            saveGame.MsgPrint("You can't remember a thing, or how you got here!");
        }
        else
        {
            if (!saveGame.HasConfusionResistance)
            {
                saveGame.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(20) + 15);
            }
            if (Program.Rng.DieRoll(3) == 1 && !saveGame.HasChaosResistance)
            {
                saveGame.MsgPrint("Thishcischs GooDSChtuff!");
                saveGame.TimedHallucinations.AddTimer(Program.Rng.RandomLessThan(150) + 150);
            }
        }
    }
}