namespace AngbandOS.Core.Scripts;
internal class WraithRandomMutationScript : UniversalScript
{
    private WraithRandomMutationScript(Game game) : base(game) { }

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