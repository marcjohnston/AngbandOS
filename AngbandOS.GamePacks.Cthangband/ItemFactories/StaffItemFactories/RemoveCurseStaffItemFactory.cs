// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RemoveCurseStaffItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(UnderscoreSymbol);
    public override string Name => "Remove Curse";
    public override string? DescriptionSyntax => "$Flavor$ Staff~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Staff~";
    public override string? FlavorSuppressedDescriptionSyntax => "Staff~ of $Name$";
    public override int Cost => 500;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override int Weight => 50;
    public override (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple => (nameof(SystemScriptsEnum.RemoveCurseScript), "1d3+4", 25, 100);
    public override string ItemClassBindingKey => nameof(StaffsItemClass);
    public override string? RechargeScriptBindingKey => nameof(SystemScriptsEnum.RechargeStaffScript);

    public override string? EatMagicScriptBindingKey => nameof(SystemScriptsEnum.StaffEatMagicScript);

    
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
