// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RestoreWisdomPotionItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(ExclamationPointSymbol);
    public override string Name => "Restore Wisdom";
    public override string? DescriptionSyntax => "$Flavor$ Potion~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Potion~";
    public override string? FlavorSuppressedDescriptionSyntax => "Potion~ of $Name$";
    public override int Cost => 300;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 25;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (25, 1)
    };
    public override int Weight => 4;
    public override (string, string?, int)? QuaffBindingTuple => (nameof(SystemScriptsEnum.RestoreWisdomScript), null, 20);

    /// <summary>
    /// Returns true, because potions are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true; // TODO: This should be a built-in function depending on what the potion does

    public override string ItemClassBindingKey => nameof(PotionsItemClass);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    public override string BreakageChanceProbabilityExpression => "100/100";
    public override string? ItemEnhancementBindingKey => nameof(EasyKnowItemFactoryItemEnhancement);
    public override int PackSort => 11;

    /// <summary>
    /// Returns 20 gold because unknown potions are not worth much.
    /// </summary>
    public override int BaseValue => 20;

    /// <summary>
    /// Returns true because potions are susceptible to freezing.
    /// </summary>
    public override bool HatesCold => true;
    public override ColorEnum Color => ColorEnum.Blue;
}
