namespace AngbandOS.Core.Scripts;
internal class BersRageRandomMutationMutationScript : UniversalScript, IGetKey
{
    private BersRageRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

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