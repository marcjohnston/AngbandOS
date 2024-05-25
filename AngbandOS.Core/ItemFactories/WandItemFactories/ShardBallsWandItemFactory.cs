// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ShardBallsWandItemFactory : WandItemFactory
{
    private ShardBallsWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Shard Balls";
    protected override string? DescriptionSyntax => "& $Flavor$ Wand~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Wand~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Wand~ of $Name$";
    public override int RodChargeCount => Game.DieRoll(2) + 1;
    public override int Cost => 95000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 75;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (75, 4)
    };
    public override int Weight => 10;

    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(ShardProjectile)), dir, 75 + Game.DieRoll(50), 2);
        return true;
    }
}
