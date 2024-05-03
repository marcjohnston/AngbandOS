// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DarknessStaffItemFactory : StaffItemFactory
{
    private DarknessStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Darkness";

    public override int StaffChargeCount => Game.DieRoll(8) + 8;

    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Darkness";
    public override int LevelNormallyFound => 5;
    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int[] Locale => new int[] { 5, 50, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (!Game.HasBlindnessResistance && !Game.HasDarkResistance)
        {
            if (Game.BlindnessTimer.AddTimer(3 + Game.DieRoll(5)))
            {
                eventArgs.Identified = true;
            }
        }
        if (Game.UnlightArea(10, 3))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
