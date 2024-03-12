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
    private AlcoholRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your body starts producing alcohol!";
    public override string HaveMessage => "Your body produces alcohol.";
    public override string LoseMessage => "Your body stops producing alcohol!";

    public override void OnProcessWorld()
    {
        if (base.SaveGame.DieRoll(6400) != 321)
        {
            return;
        }
        if (SaveGame.HasChaosResistance && SaveGame.HasConfusionResistance)
        {
            return;
        }
        SaveGame.Disturb(false);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        SaveGame.MsgPrint("You feel a SSSCHtupor cOmINg over yOu... *HIC*!");
        if (base.SaveGame.DieRoll(20) == 1)
        {
            SaveGame.MsgPrint(null);
            if (base.SaveGame.DieRoll(3) == 1)
            {
                SaveGame.LoseAllInfo();
            }
            else
            {
                SaveGame.RunScript(nameof(DarkScript));
            }
            SaveGame.RunScriptInt(nameof(TeleportSelfScript), 100);
            SaveGame.RunScript(nameof(DarkScript));
            SaveGame.MsgPrint("You wake up somewhere with a sore head...");
            SaveGame.MsgPrint("You can't remember a thing, or how you got here!");
        }
        else
        {
            if (!SaveGame.HasConfusionResistance)
            {
                SaveGame.ConfusedTimer.AddTimer(base.SaveGame.RandomLessThan(20) + 15);
            }
            if (base.SaveGame.DieRoll(3) == 1 && !SaveGame.HasChaosResistance)
            {
                SaveGame.MsgPrint("Thishcischs GooDSChtuff!");
                SaveGame.HallucinationsTimer.AddTimer(base.SaveGame.RandomLessThan(150) + 150);
            }
        }
    }
}