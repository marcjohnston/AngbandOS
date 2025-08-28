namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxeSpleenSlicerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Spleens Slicer heals you
    public override string? ActivationName => nameof(ActivationsEnum.Heal4d8AndWoundsEvery3p1d3Activation);
    public override string FriendlyName => "'Spleen Slicer'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "1";
    public override string? BonusStrengthRollExpression => "1";
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override int? Value => 21000;
    public override string BonusHitsRollExpression => "4";
    public override string BonusDamageRollExpression => "3";
    public override ColorEnum? Color => ColorEnum.Grey;
}
