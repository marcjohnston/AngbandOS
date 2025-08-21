namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class VampirismMutationScript : UniversalScript, IGetKey
{
    private VampirismMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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