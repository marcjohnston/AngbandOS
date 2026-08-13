namespace AngbandOS.Core.Scripts;
internal class CowardiceRandomMutationMutationScript : UniversalScript, IGetKey
{
    private CowardiceRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

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