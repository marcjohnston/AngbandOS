namespace AngbandOS.Core.Scripts;
internal class SpToHpRandomMutationScript : UniversalScript, IGetKey
{
    private SpToHpRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(2000) != 1)
        {
            return;
        }
        int wounds = Game.MaxHealth.IntValue - Game.Health.IntValue;
        if (wounds <= 0)
        {
            return;
        }
        int healing = Game.Mana.IntValue;
        if (healing > wounds)
        {
            healing = wounds;
        }
        Game.RestoreHealth(healing);
        Game.Mana.IntValue -= healing;
    }
}