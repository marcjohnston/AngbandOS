// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonsBreathWandItemFactory : WandItemFactory
{
    private DragonsBreathWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Dragon's Breath";

    public override int RodChargeCount => Game.DieRoll(3) + 1;
    public override int Cost => 2400;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Dragon's Breath";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 60;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (60, 4)
    };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        switch (Game.RandomLessThan(5))
        {
            case 0:
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 100, -3);
                break;
            case 1:
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), dir, 80, -3);
                break;
            case 2:
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 100, -3);
                break;
            case 3:
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, 80, -3);
                break;
            case 4:
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), dir, 60, -3);
                break;
            default:
                throw new Exception("Internal error.");
        }
        return true;
    }
}
