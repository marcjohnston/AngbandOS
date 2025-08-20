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
    private AlcoholRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your body starts producing alcohol!";
    public override string HaveMessage => "Your body produces alcohol.";
    public override string LoseMessage => "Your body stops producing alcohol!";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(6400) != 321)
        {
            return;
        }
        if (Game.HasChaosResistance && Game.HasConfusionResistance)
        {
            return;
        }
        Game.Disturb(false);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        Game.MsgPrint("You feel a SSSCHtupor cOmINg over yOu... *HIC*!");
        if (base.Game.DieRoll(20) == 1)
        {
            Game.MsgPrint(string.Empty);
            if (base.Game.DieRoll(3) == 1)
            {
                Game.LoseAllInfo();
            }
            else
            {
                Game.RunScript(nameof(DarkScript));
            }
            Game.RunScript(nameof(TeleportSelf100TeleportSelfScript));
            Game.RunScript(nameof(DarkScript));
            Game.MsgPrint("You wake up somewhere with a sore head...");
            Game.MsgPrint("You can't remember a thing, or how you got here!");
        }
        else
        {
            if (!Game.HasConfusionResistance)
            {
                Game.ConfusionTimer.AddTimer(base.Game.RandomLessThan(20) + 15);
            }
            if (base.Game.DieRoll(3) == 1 && !Game.HasChaosResistance)
            {
                Game.MsgPrint("Thishcischs GooDSChtuff!");
                Game.HallucinationsTimer.AddTimer(base.Game.RandomLessThan(150) + 150);
            }
        }
    }
}