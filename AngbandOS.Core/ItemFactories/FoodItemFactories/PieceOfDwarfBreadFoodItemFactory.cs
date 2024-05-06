// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PieceOfDwarfBreadFoodItemFactory : FoodItemFactory
{
    private PieceOfDwarfBreadFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Piece of Dwarf Bread";

    public override int Cost => 16;
    public override int DamageDice => 1;
    public override int DamageSides => 6;
    public override string FriendlyName => "& Piece~ of Dwarf Bread";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override int InitialNutritionalValue => 7500;
    public override int Weight => 3;

    /// <summary>
    /// Returns false, because dwarf bread isn't actually consumed.
    /// </summary>
    public override bool IsConsumedWhenEaten => false;

    public override bool Eat()
    {
        return Game.RunIdentifableScript(nameof(EatDwarfBreadScript));
    }
}
