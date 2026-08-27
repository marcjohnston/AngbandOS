namespace AngbandOS.Core.Scripts;
internal class BersRageRandomMutationScript : UniversalScript, IGetKey
{
    private BersRageRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("RAAAAGHH!");
        Game.MsgPrint("You feel a fit of rage coming over you!");
        Game.SuperheroismTimer.AddTimer(10 + base.Game.DieRoll(Game.ExperienceLevel.IntValue));
    }
}