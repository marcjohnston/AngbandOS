namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class LauncherMutationScript : UniversalScript, IGetKey
{
    private LauncherMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.DoCmdThrow(2 + (Game.ExperienceLevel.IntValue / 16));
    }
}