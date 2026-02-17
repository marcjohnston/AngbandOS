namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExecutionersSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "260"),
        (nameof(ValueAttribute), "850"),
        (nameof(DamageDiceAttribute), "4"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? HatesAcid => "true";
}
