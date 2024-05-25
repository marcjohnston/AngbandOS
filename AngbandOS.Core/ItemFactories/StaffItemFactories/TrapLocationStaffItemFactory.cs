// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TrapLocationStaffItemFactory : StaffItemFactory
{
    private TrapLocationStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Trap Location";
    protected override string? DescriptionSyntax => "& $Flavor$ Staff~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Staff~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Staff~ of $Name$";
    public override int StaffChargeCount => Game.DieRoll(5) + 6;

    public override int Cost => 350;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.DetectTraps())
        {
            eventArgs.Identified = true;
        }
    }
}
