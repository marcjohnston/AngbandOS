namespace AngbandOS.Core.Scripts;
internal class NauseaRandomMutationMutationScript : UniversalScript, IGetKey
{
    private NauseaRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

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