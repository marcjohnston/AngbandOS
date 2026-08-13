namespace AngbandOS.Core.Scripts;
internal class PolyWoundRandomMutationMutationScript : UniversalScript, IGetKey
{
    private PolyWoundRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) == 1)
        {
            Game.RunScript(nameof(PolymorphWoundsScript));
        }
    }
}