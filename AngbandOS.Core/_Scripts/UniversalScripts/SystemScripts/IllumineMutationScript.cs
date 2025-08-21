namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class IllumineMutationScript : UniversalScript, IGetKey
{
    private IllumineMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.LightArea(base.Game.DiceRoll(2, Game.ExperienceLevel.IntValue / 2), (Game.ExperienceLevel.IntValue / 10) + 1);
    }
}