namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronShotAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "2"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "3"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
}

