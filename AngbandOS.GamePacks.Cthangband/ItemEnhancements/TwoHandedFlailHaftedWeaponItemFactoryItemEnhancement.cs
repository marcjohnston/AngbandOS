namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedFlailHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "280"),
        (nameof(ValueAttribute), "590"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(DiceSidesAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.Yellow;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
