// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HealingStaffItemFactory : StaffItemFactory
{
    private HealingStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Healing";
    protected override string? DescriptionSyntax => "$Flavor$ Staff~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Staff~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Staff~ of $Name$";
    public override string? StaffChargeCountRollExpression => "1d2+1";
    public override int Cost => 5000;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (70, 2)
    };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.RestoreHealth(300))
        {
            eventArgs.Identified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            eventArgs.Identified = true;
        }
    }
    public override int StaffChargeValue => 250;
}
