namespace AngbandOS.Core.Scripts;
internal class PolyWoundRandomMutationScript : UniversalScript
{
    private PolyWoundRandomMutationScript(Game game) : base(game) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) == 1)
        {
            Game.RunScript(nameof(PolymorphWoundsScript));
        }
    }
}