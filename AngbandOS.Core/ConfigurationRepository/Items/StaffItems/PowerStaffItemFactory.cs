// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PowerStaffItemFactory : StaffItemFactory
{
    private PowerStaffItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "Power";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.Rng.DieRoll(3) + 1;
    }
    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 4000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Power";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (SaveGame.DispelMonsters(120))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new PowerStaffItem(SaveGame);
}
