// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ConfusionMushroomFoodItemFactory : ItemFactory
{
    private ConfusionMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(CommaSymbol);
    public override string Name => "Confusion";
    protected override string? DescriptionSyntax => "$Flavor$ Mushroom~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Mushroom~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Mushroom~ of $Name$";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 1;

    public override string? EatScriptName => nameof(EatConfusionScript);
    protected override string ItemClassName => nameof(MushroomItemClass);

    /// <summary>
    /// Returns a nutritional value of 500 turns for all mushrooms.
    /// </summary>
    public override int InitialNutritionalValue => 500;
    public override int PercentageBreakageChance => 100;
    public override bool EasyKnow => true;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Food;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override int PackSort => 9;
    public override int BaseValue => 5;

    public override ColorEnum Color => ColorEnum.Green;
    public virtual bool VanishesWhenEatenBySkeletons => false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public virtual bool IsConsumedWhenEaten => true;

    /// <summary>
    /// Returns true, because food items can be eaten by monsters.
    /// </summary>
    public override bool CanBeEatenByMonsters => true;

    /// <summary>
    /// Returns true, because food items can be eaten by the player.
    /// </summary>
    public override bool CanBeEaten => true;
}
