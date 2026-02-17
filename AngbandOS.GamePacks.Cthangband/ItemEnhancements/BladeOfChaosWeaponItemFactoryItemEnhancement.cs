namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Chaotic => true;
    public override bool? ResChaos => true;
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "180"),
        (nameof(ValueAttribute), "4000"),
        (nameof(DamageDiceAttribute), "6"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.Purple;
    public override string? HatesAcid => "true";
}
