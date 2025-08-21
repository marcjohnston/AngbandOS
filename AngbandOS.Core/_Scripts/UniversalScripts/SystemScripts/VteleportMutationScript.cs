namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class VteleportMutationScript : UniversalScript, IGetKey
{
    private VteleportMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.MsgPrint("You concentrate...");
        Game.RunScript(nameof(TeleportSelf10P4xTeleportSelfScript));
    }
}