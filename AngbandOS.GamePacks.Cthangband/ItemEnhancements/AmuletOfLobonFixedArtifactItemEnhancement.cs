namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfLobonFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.ProtectionFromEvilActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "60000"),
        (nameof(ConstitutionAttribute), "2"),
    };
    public override string FriendlyName => "of Lobon";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
}
