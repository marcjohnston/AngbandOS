namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MainGaucheOfDefenceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "15"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "22500"),
        (nameof(SpeedAttribute), "3"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Defence";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayGiant => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
