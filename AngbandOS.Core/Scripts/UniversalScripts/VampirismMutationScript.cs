namespace AngbandOS.Core.Scripts;
internal class VampirismMutationScript : ActiveMutationScript
{
    private VampirismMutationScript(Game game) : base(game) { }
    public override string Name => "vampiric drain";
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (Game.RunIdentifiedScript(nameof(OldDrainLife2xProjectileScript)))
        {
            Game.RestoreHealth(Game.ExperienceLevel.IntValue + base.Game.DieRoll(Game.ExperienceLevel.IntValue));
        }
    }
}