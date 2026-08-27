namespace AngbandOS.Core.Scripts;
internal class PolyWoundRandomMutationScript : UniversalScript, IGetKey
{
    private PolyWoundRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) == 1)
        {
            Game.RunScript(nameof(PolymorphWoundsScript));
        }
    }
}