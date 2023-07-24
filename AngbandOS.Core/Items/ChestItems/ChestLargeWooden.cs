// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ChestLargeWooden : ChestItemFactory
{
    private ChestLargeWooden(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<TildeSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Large wooden chest";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 60;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "& Large wooden chest~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Weight => 500;
    public override bool IsSmall => false;
    public override int NumberOfItemsContained => 2;
    public override Item CreateItem() => new LargeWoodenChestItem(SaveGame);
}
