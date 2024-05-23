// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StripOfVenisonFoodItemFactory : FoodItemFactory
{
    private StripOfVenisonFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Strip of Venison";

    public override int Cost => 2;
    public override string FriendlyName => "& Strip~ of Venison";
    public override int InitialNutritionalValue => 1500;
    public override int Weight => 2;
    public override string? EatScriptName => nameof(EatGoodFoodScript);
}
