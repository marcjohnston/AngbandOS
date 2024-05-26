// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AcidBallsWandItemFactory : WandItemFactory
{
    private AcidBallsWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override int RodChargeCount => Game.DieRoll(5) + 2;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Acid Balls";
    protected override string? DescriptionSyntax => "$Flavor$ Wand~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Wand~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Wand~ of $Name$";
    public override int Cost => 1650;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int Weight => 10;
    public override bool ActivateWand(int dir)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 60, 2);
        return true;
    }
}
