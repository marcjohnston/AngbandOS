namespace AngbandOS.Core.Scripts;
internal class WraithRandomMutationMutationScript : UniversalScript, IGetKey
{
    private WraithRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || Game.DieRoll(3000) != 13)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("You feel insubstantial!");
        Game.MsgPrint(string.Empty);
        Game.EtherealnessTimer.AddTimer(Game.DieRoll(Game.ExperienceLevel.IntValue / 2) + Game.ExperienceLevel.IntValue / 2);
    }
}