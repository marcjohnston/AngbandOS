// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HasteMonsterWandItemFactory : ItemFactory
{
    private HasteMonsterWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Haste Monster";
    protected override string? DescriptionSyntax => "$Flavor$ Wand~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Wand~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Wand~ of $Name$";
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 2;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (2, 1)
    };
    public override int Weight => 10;
    protected override (string, string, int, int)? AimingBinderDetails => (nameof(HasteMonsterScript), "1d20+8", 0, 150);
    protected override string ItemClassName => nameof(WandsItemClass);

    protected override string? RechargeScriptName => nameof(RechargeWandScript);

    protected override string? EatMagicScriptName => nameof(WandEatMagicScript);

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