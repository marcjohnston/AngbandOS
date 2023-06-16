// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PintOfFineWineFoodItemFactory : FoodItemFactory
{
    private PintOfFineWineFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override Colour Colour => Colour.Red;
    public override string Name => "Pint of Fine Wine";

    public override int Cost => 2;
    public override string FriendlyName => "& Pint~ of Fine Wine";
    public override int Pval => 1000;
    public override int? SubCategory => 39;
    public override int Weight => 10;
    public override bool Eat()
    {
        SaveGame.MsgPrint("That tastes good.");
        return true;
    }
    public override Item CreateItem() => new PintOfFineWineFoodItem(SaveGame);
}
