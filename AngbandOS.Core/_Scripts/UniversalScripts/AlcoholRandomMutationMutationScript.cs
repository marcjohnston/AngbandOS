namespace AngbandOS.Core.Scripts;
internal class AlcoholRandomMutationMutationScript : UniversalScript, IGetKey
{
    private AlcoholRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(6400) != 321)
        {
            return;
        }
        if (Game.HasChaosResistance)
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