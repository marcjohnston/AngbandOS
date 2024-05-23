// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MagicMissileWandItemFactory : WandItemFactory
{
    private MagicMissileWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Magic Missile";

    public override int RodChargeCount => Game.DieRoll(10) + 6;
    public override int Cost => 200;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Magic Missile";
    public override int LevelNormallyFound => 2;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (2, 1)
    };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, Game.DiceRoll(2, 6));
        return true;
    }
}
