namespace AngbandOS.Core.Scripts;
internal class IlluminateMutationScript : ActiveMutationScript
{
    private IlluminateMutationScript(Game game) : base(game) { }
    public override string Name => "illuminate";
    public override void ExecuteScript()
    {
        Game.LightArea(base.Game.DiceRoll(2, Game.ExperienceLevel.IntValue / 2), (Game.ExperienceLevel.IntValue / 10) + 1);
    }
}