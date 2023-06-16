// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class DoomAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private DoomAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '"';
    public override string Name => "DOOM";

    public override bool Cha => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override bool Con => true;
    public override bool Cursed => true;
    public override bool Dex => true;
    public override string FriendlyName => "DOOM";
    public override bool HideType => true;
    public override bool Int => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Pval => -5;
    public override bool Str => true;
    public override int Weight => 3;
    public override bool Wis => true;
    public override Item CreateItem() => new DoomAmuletJeweleryItem(SaveGame);
}
