// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class DarknessStaffItemFactory : StaffItemFactory
{
    private DarknessStaffItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "Darkness";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Darkness";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 50, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (!SaveGame.HasBlindnessResistance && !SaveGame.HasDarkResistance)
        {
            if (SaveGame.TimedBlindness.AddTimer(3 + SaveGame.Rng.DieRoll(5)))
            {
                eventArgs.Identified = true;
            }
        }
        if (SaveGame.UnlightArea(10, 3))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new DarknessStaffItem(SaveGame);
}
