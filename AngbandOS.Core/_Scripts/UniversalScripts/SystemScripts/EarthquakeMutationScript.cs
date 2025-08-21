namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class EarthquakeMutationScript : UniversalScript, IGetKey
{
    private EarthquakeMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        if (!Game.IsQuest(Game.CurrentDepth) && Game.CurrentDepth != 0)
        {
            Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 10);
        }
    }
}