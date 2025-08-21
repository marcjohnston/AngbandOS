namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class SterilityMutationScript : UniversalScript, IGetKey
{
    private SterilityMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.MsgPrint("You suddenly have a headache!");
        Game.TakeHit(base.Game.DieRoll(30) + 30, "the strain of forcing abstinence");
        Game.NumRepro += Constants.MaxRepro;
    }
}