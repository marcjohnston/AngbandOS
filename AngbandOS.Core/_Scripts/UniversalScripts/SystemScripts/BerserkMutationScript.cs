namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class BerserkMutationScript : UniversalScript, IGetKey
{
    private BerserkMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.SuperheroismTimer.AddTimer(base.Game.DieRoll(25) + 25);
        Game.RestoreHealth(30);
        Game.FearTimer.ResetTimer();
    }
}