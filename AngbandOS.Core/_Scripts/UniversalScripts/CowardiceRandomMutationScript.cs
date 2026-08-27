namespace AngbandOS.Core.Scripts;
internal class CowardiceRandomMutationScript : UniversalScript, IGetKey
{
    private CowardiceRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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