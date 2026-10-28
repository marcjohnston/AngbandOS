namespace AngbandOS.Core.Scripts;
internal class BanishAllRandomMutationScript : UniversalScript, IGetKey
{
    private BanishAllRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(9000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("You suddenly feel almost lonely.");
        Game.RunScript(nameof(TeleportAwayAll100ProjectileScript));
        Game.MsgPrint(string.Empty);
    }
}