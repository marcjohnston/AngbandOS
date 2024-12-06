// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OfTheMagiStaffItemFactory : ItemFactory
{
    private OfTheMagiStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(UnderscoreSymbol);
    public override string Name => "the Magi";
    protected override string? DescriptionSyntax => "$Flavor$ Staff~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Staff~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Staff~ of $Name$";
    public override int Cost => 4500;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (70, 2)
    };
    public override int Weight => 50;
    protected override (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple => (nameof(OfTheMagiScript), "1d2+2", 225, 100);
    protected override string ItemClassBindingKey => nameof(StaffsItemClass);
    protected override string? RechargeScriptBindingKey => nameof(RechargeStaffScript);

    protected override string? EatMagicScriptBindingKey => nameof(StaffEatMagicScript);

    
    /// <summary>
    /// Returns true, because staffs are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override int PackSort => 15;
    public override int BaseValue => 70;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.Purple;
}
