// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RationFoodItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Ration of Food";

    public override int Cost => 3;
    public override string? DescriptionSyntax => "Ration~ of Food";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1),
        (5, 1),
        (10, 1)
    };
    public override int InitialNutritionalValue => 5000;
    public override int Weight => 10;

    public override string? EatScriptBindingKey => nameof(SystemScriptsEnum.EatGoodFoodScript);
    public override string ItemClassBindingKey => nameof(FoodItemClass);
    public override string BreakageChanceProbabilityExpression => "100/100";
    public override string? ItemEnhancementBindingKey => nameof(EasyKnowItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
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
