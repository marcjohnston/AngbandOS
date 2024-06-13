// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TeleportationStaffItemFactory : StaffItemFactory
{
    private TeleportationStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override int StaffChargeCount => Game.DieRoll(4) + 5;
    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Teleportation";
    protected override string? DescriptionSyntax => "$Flavor$ Staff~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Staff~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Staff~ of $Name$";
    public override int Cost => 2000;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), 100);
        eventArgs.Identified = true;
    }
    public override int StaffChargeValue => 100;
}
