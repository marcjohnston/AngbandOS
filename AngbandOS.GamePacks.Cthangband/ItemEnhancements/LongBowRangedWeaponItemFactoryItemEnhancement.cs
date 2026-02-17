namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowRangedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? ArtifactBiasCanSlay => true;
    public override bool? CanApplyBlowsBonus => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "40"),
        (nameof(ValueAttribute), "120"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
