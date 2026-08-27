namespace AngbandOS.Core.Scripts;
internal class TelekinesMutationScript : ActiveMutationScript
{
    private TelekinesMutationScript(Game game) : base(game) { }
    public override string Name => "telekinesis";
    public override void ExecuteScript()
    {
        Game.MsgPrint("You concentrate...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Game.SummonItem(dir, Game.ExperienceLevel.IntValue * 10, true);
        }
    }
}