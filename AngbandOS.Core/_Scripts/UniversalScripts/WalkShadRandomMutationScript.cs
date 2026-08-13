namespace AngbandOS.Core.Scripts;
internal class WalkShadRandomMutationScript : UniversalScript, IGetKey
{
    private WalkShadRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (!Game.HasAntiMagic && base.Game.DieRoll(12000) == 1)
        {
            Game.AlterReality();
        }
    }
}