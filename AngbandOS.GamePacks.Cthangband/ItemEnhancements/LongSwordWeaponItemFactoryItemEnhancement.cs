namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "130"),
        (nameof(ValueAttribute), "300"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
