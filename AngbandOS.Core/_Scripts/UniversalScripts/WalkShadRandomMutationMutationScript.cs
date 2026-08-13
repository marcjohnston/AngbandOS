namespace AngbandOS.Core.Scripts;
internal class WalkShadRandomMutationMutationScript : UniversalScript, IGetKey
{
    private WalkShadRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (!Game.HasAntiMagic && base.Game.DieRoll(12000) == 1)
        {
            Game.AlterReality();
        }
    }
}