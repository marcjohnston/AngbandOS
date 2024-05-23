// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PieceOfElvishWaybreadFoodItemFactory : FoodItemFactory
{
    private PieceOfElvishWaybreadFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Piece of Elvish Waybread";

    public override int Cost => 10;
    public override string FriendlyName => "& Piece~ of Elvish Waybread";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1),
        (10, 1),
        (20, 1)
    };
    public override int InitialNutritionalValue => 7500;
    public override int Weight => 3;
    public override string? EatScriptName => nameof(EatElvenBreadScript);

    /// <summary>
    /// Returns true because waybread vanishes when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;
    
}
