namespace AngbandOS.Core.Scripts;
internal class EarthquakeMutationScript : ActiveMutationScript
{
    private EarthquakeMutationScript(Game game) : base(game) { }
    public override string Name => "earthquake";
    public override void ExecuteScript()
    {
        if (!Game.IsQuest(Game.CurrentDepth) && Game.CurrentDepth != 0)
        {
            Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 10);
        }
    }
}