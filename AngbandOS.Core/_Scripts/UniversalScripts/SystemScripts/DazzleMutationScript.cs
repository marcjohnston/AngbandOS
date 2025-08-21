namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class DazzleMutationScript : UniversalScript, IGetKey
{
    private DazzleMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.RunScript(nameof(StunAtLos1xProjectileScript));
        Game.RunScript(nameof(OldConfuseAtLos4xProjectileScript));
        Game.RunScript(nameof(TurnAllAtLos4xProjectileScript));
    }
}