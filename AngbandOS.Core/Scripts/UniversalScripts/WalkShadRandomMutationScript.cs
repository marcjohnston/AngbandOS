namespace AngbandOS.Core.Scripts;
internal class WalkShadRandomMutationScript : UniversalScript
{
    private WalkShadRandomMutationScript(Game game) : base(game) { }
    public override void ExecuteScript()
    {
        if (!Game.HasAntiMagic && base.Game.DieRoll(12000) == 1)
        {
            Game.AlterReality();
        }
    }
}