namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "775"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(DiceSidesAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
