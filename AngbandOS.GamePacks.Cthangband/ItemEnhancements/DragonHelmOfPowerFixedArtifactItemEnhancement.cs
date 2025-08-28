namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonHelmOfPowerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Dragon Helm and Terror Mask cause fear
    public override string? ActivationName => nameof(ActivationsEnum.Terror40xEvery3xp10Activation);
    public override int? TreasureRating => 20;
    public override string FriendlyName => "of Power";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a dragon helm which provides no light.
    /// </summary>
    public override int? Radius => 3;

    public override string? BonusConstitutionRollExpression => "4";
    public override string? BonusDexterityRollExpression => "4";
    public override string? BonusStrengthRollExpression => "4";
    public override bool? ResAcid => true;
    public override bool? ResBlind => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? Telepathy => true;
    public override int? Weight => 25;
    public override int? Value => 300000;
    public override string BonusAttacksRollExpression => "20";
    public override ColorEnum? Color => ColorEnum.BrightGreen;
}
