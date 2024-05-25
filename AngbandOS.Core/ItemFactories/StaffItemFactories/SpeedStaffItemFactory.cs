// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpeedStaffItemFactory : StaffItemFactory
{
    private SpeedStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Speed";
    protected override string? DescriptionSyntax => "& $Flavor$ Staff~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Staff~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Staff~ of $Name$";
    public override int StaffChargeCount => Game.DieRoll(3) + 4;

    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.HasteTimer.Value == 0)
        {
            if (Game.HasteTimer.SetTimer(Game.DieRoll(30) + 15))
            {
                eventArgs.Identified = true;
            }
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
    }
}
