// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PintOfFineWineFoodItemFactory : ItemFactory
{
    private PintOfFineWineFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Pint of Fine Wine";

    public override int Cost => 2;
    protected override string? DescriptionSyntax => "Pint~ of Fine Wine";
    public override int InitialNutritionalValue => 1000;
    public override int Weight => 10;
    public override string? EatScriptName => nameof(EatGoodFoodScript);
    protected override string ItemClassName => nameof(FoodItemClass);
    public override int PercentageBreakageChance => 100;
    public override bool EasyKnow => true;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override int PackSort => 9;
    public override int BaseValue => 5;

    /// <summary>
    /// Returns true, because food items can be eaten by monsters.
    /// </summary>
    public override bool CanBeEatenByMonsters => true;

    /// <summary>
    /// Returns true, because food items can be eaten by the player.
    /// </summary>
    public override bool CanBeEaten => true;
}