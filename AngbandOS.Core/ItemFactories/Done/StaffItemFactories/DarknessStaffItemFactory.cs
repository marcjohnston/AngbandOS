// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DarknessStaffItemFactory : ItemFactory
{
    private DarknessStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool IsBroken => true;

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Darkness";
    protected override string? DescriptionSyntax => "$Flavor$ Staff~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Staff~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Staff~ of $Name$";
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1),
        (50, 1)
    };
    public override int Weight => 50;
    protected override (string UseScriptName, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBinderDetails => (nameof(DarknessIdentifableAndUsedScript), "1d8+8", 0, 100);
    protected override string ItemClassName => nameof(StaffsItemClass);
    protected override string? RechargeScriptName => nameof(RechargeStaffScript);

    protected override string? EatMagicScriptName => nameof(StaffEatMagicScript);

    
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