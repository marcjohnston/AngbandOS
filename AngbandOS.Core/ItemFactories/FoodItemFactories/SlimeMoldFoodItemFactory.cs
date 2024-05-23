// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlimeMoldFoodItemFactory : FoodItemFactory
{
    private SlimeMoldFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Slime Mold";

    public override int Cost => 2;
    public override string FriendlyName => "& Slime Mold~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int InitialNutritionalValue => 3000;
    public override int Weight => 5;
    public override string? EatScriptName => nameof(EatSlimeMoldScript);
}
