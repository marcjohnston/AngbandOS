namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScythePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "250"),
        (nameof(ValueAttribute), "800"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(DiceSidesAttribute), "3"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
