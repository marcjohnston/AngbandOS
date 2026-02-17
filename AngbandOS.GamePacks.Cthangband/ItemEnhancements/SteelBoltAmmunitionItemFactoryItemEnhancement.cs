namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelBoltAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "2"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
}

