namespace AngbandOS.Core.Scripts;
internal class HpToSpRandomMutationMutationScript : UniversalScript, IGetKey
{
    private HpToSpRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(4000) != 1)
        {
            return;
        }
        int wounds = Game.MaxMana.IntValue - Game.Mana.IntValue;
        if (wounds <= 0)
        {
            return;
        }
        int healing = Game.Health.IntValue;
        if (healing > wounds)
        {
            healing = wounds;
        }
        Game.Mana.IntValue += healing;
        Game.TakeHit(healing, "blood rushing to the head");
    }
}