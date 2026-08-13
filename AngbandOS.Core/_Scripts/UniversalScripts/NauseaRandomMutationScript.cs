namespace AngbandOS.Core.Scripts;
internal class NauseaRandomMutationScript : UniversalScript, IGetKey
{
    private NauseaRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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