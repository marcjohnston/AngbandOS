namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class TelekinesMutationScript : UniversalScript, IGetKey
{
    private TelekinesMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.MsgPrint("You concentrate...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Game.SummonItem(dir, Game.ExperienceLevel.IntValue * 10, true);
        }
    }
}