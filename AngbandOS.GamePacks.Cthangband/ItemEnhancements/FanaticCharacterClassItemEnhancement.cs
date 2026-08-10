namespace AngbandOS.GamePacks.Cthangband;

public class FanaticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(ValueAttribute), "6300"),
        (nameof(DisarmTrapsAttribute), "20"),
        (nameof(UseDeviceAttribute), "24"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(SavingThrowBonusPerLevelAttribute), "10"),
        (nameof(UseDeviceAttribute), "24"),
        (nameof(UseDeviceBonusPerLevelAttribute), "11")
    };
}
