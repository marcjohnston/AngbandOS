namespace AngbandOS.Core.Scripts;
internal class BanishAllRandomMutationScript : UniversalScript
{
    private BanishAllRandomMutationScript(Game game) : base(game) { }

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