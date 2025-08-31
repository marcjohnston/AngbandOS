//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AggravateMonsterScrollItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns true, because scrolls are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override string Name => "Aggravate Monster";
    public override string? DescriptionSyntax => "Scroll~ titled \"$Flavor$\" of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "Scroll~ titled \"$Flavor$\"";
    public override string? FlavorSuppressedDescriptionSyntax => "Scroll~ of $Name$";
    public override int LevelNormallyFound => 5;
    // AngbandOS: 2022 Marc Johnston
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };

    public override (string, int)? ReadBindingTuple => (nameof(SystemScriptsEnum.AggravateMonstersScript), 10);
    public override string ItemClassBindingKey => nameof(ScrollsItemClass);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    public override string BreakageChanceProbabilityExpression => "50/100";

    public override string? ItemEnhancementBindingKey => nameof(AggravateMonsterScrollItemFactoryItemEnhancement);
    public override int PackSort => 12;
    public override int BaseValue => 20;

}
