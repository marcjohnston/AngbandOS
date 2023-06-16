// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PieceOfDwarfBreadFoodItemFactory : FoodItemFactory
{
    private PieceOfDwarfBreadFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Piece of Dwarf Bread";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 16;
    public override int Dd => 1;
    public override int Ds => 6;
    public override string FriendlyName => "& Piece~ of Dwarf Bread";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Pval => 7500;
    public override int? SubCategory => 41;
    public override int Weight => 3;

    /// <summary>
    /// Returns false, because dwarf bread isn't actually consumed.
    /// </summary>
    public override bool IsConsumedWhenEaten => false;

    public override bool Eat()
    {
        SaveGame.MsgPrint("You look at the dwarf bread, and don't feel quite so hungry anymore.");
        return true;
    }
    public override Item CreateItem() => new PieceOfDwarfBreadFoodItem(SaveGame);
}
