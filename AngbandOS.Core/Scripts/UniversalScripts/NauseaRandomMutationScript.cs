namespace AngbandOS.Core.Scripts;
internal class NauseaRandomMutationScript : UniversalScript
{
    private NauseaRandomMutationScript(Game game) : base(game) { }

    public override void ExecuteScript()
    {
        if (Game.HasSlowDigestion || base.Game.DieRoll(9000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("Your stomach roils, and you lose your lunch!");
        Game.MsgPrint(string.Empty);
        Game.SetFood(Constants.PyFoodWeak);
    }
}