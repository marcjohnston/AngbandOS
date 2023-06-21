// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ChestLargeSteel : ChestItemClass
{
    private ChestLargeSteel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '~';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Large steel chest";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "& Large steel chest~";
    public override int Level => 55;
    public override int[] Locale => new int[] { 55, 0, 0, 0 };
    public override int Weight => 1000;
    public override bool IsSmall => false;
    public override int NumberOfItemsContained => 6;
    public override Item CreateItem() => new LargeSteelChestItem(SaveGame);
}
