namespace AngbandOS.Core.Scripts;
internal class LauncherMutationScript : ActiveMutationScript
{
    private LauncherMutationScript(Game game) : base(game) { }
    public override string Name => "throw object";
    public override void ExecuteScript()
    {
        Game.DoCmdThrow(2 + (Game.ExperienceLevel.IntValue / 16));
    }
}