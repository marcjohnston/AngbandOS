namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadAxeOfNodensFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(ValueAttribute), "50000"),
        (nameof(MeleeToHitAttribute), "13"),
        (nameof(ToDamageAttribute), "19"),
    };
    public override string FriendlyName => "of Nodens";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
