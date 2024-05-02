// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RationFoodItemFactory : FoodItemFactory
{
    private RationFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Ration of Food";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 3;
    public override string FriendlyName => "& Ration~ of Food";
    public override int[] Locale => new int[] { 0, 5, 10, 0 };
    public override int InitialNutritionalValue => 5000;
    public override int Weight => 10;

    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.MsgPrint("That tastes good.");
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
