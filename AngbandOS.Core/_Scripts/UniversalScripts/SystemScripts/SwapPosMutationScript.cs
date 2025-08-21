namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class SwapPosMutationScript : UniversalScript, IGetKey
{
    private SwapPosMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.TeleportSwap(dir);
    }
}