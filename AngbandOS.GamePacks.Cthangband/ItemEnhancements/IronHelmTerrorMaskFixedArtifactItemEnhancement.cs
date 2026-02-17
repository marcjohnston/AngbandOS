namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Terror40xEvery3xp10Activation);
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Terror Mask'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImCold => true;
    public override bool? NoMagic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SearchAttribute), "-1"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "25"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "40000"),
        (nameof(WisdomAttribute), "-1"),
    };
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResDisen => true;
    public override bool? ResFear => true;
    public override bool? ResPois => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? Teleport => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
