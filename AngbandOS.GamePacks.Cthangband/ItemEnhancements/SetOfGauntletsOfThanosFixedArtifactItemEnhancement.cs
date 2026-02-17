namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfThanosFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "-12"),
        (nameof(MeleeToHitAttribute), "-11"),
        (nameof(ValueAttribute), "40000"),
        (nameof(DexterityAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override bool? Aggravate => true;
    public override bool? IsCursed => true;
    public override bool? DreadCurse => true;
    public override string FriendlyName => "of Thanos";
    public override bool? HeavyCurse => true;
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImCold => true;
    public override bool? ImFire => true;
    public override bool? ResChaos => true;
    public override bool? ResDisen => true;
    public override bool? ResNether => true;
    public override bool? ResNexus => true;
    public override bool? ResPois => true;
    public override bool? ShowMods => true;
    public override bool? Teleport => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
