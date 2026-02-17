namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalberdPolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "190"),
        (nameof(ValueAttribute), "430"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
