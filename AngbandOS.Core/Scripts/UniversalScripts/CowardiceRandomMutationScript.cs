namespace AngbandOS.Core.Scripts;
internal class CowardiceRandomMutationScript : UniversalScript
{
    private CowardiceRandomMutationScript(Game game) : base(game) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) != 13)
        {
            return;
        }
        if (Game.HasFearResistance)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("It's so dark... so scary!");
        Game.FearTimer.AddTimer(13 + base.Game.DieRoll(26));
    }
}