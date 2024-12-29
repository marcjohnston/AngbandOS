// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TameMonsterWandItemFactory : ItemFactory
{
    private TameMonsterWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(MinusSignSymbol);
    public override string Name => "Tame Monster";
    protected override string? DescriptionSyntax => "$Flavor$ Wand~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Wand~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Wand~ of $Name$";
    public override int Cost => 1500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 2)
    };
    public override int Weight => 10;
    protected override (string, string, int, int)? AimingBindingTuple => (nameof(Charm45ProjectileScript), "1d6+2", 75, 150);
    protected override string ItemClassBindingKey => nameof(WandsItemClass);

    protected override string? RechargeScriptBindingKey => nameof(RechargeWandScript);

    protected override string? EatMagicScriptBindingKey => nameof(WandEatMagicScript);

    /// <summary>
    /// Returns true, because wands are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string BreakageChanceProbabilityExpression => "25/100";
    public override int PackSort => 14;
    public override int BaseValue => 50;
    public override bool HatesElectricity => true;

    public override ColorEnum Color => ColorEnum.Chartreuse;
}
