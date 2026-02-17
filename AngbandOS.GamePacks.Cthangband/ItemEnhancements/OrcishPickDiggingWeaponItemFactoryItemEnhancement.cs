namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrcishPickDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "150"),
        (nameof(ValueAttribute), "300"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "3"),
    };
    public override ColorEnum? Color => ColorEnum.Green;
}
