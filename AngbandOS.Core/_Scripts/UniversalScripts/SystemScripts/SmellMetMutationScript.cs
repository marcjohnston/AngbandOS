namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class SmellMetMutationScript : UniversalScript, IGetKey
{
    private SmellMetMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.DetectTreasure();
    }
}