namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RoundedPebbleShotAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "4"),
        (nameof(ValueAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
}

