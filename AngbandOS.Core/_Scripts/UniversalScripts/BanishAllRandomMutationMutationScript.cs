namespace AngbandOS.Core.Scripts;
internal class BanishAllRandomMutationMutationScript : UniversalScript, IGetKey
{
    private BanishAllRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

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