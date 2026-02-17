namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScytheOfSlicingPolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "250"),
        (nameof(ValueAttribute), "3500"),
        (nameof(DamageDiceAttribute), "8"),
        (nameof(DiceSidesAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
