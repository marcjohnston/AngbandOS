namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakDarknessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Darkness sends monsters to sleep
    public override string? ActivationName => nameof(ActivationsEnum.SleepActivation);
    public override string FriendlyName => "'Darkness'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? BonusStealthRollExpression => "2";
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool? ResAcid => true;
    public override bool? ResDark => true;
    public override int? Value => 13000;
    public override string BonusAttacksRollExpression => "4";
    public override ColorEnum? Color => ColorEnum.Green;
}
