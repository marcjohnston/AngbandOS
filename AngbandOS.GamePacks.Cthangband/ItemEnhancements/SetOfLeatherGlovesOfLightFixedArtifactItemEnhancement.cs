namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesOfLightFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.MagicMissile2d6Every2DirectionalActivation);
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Light";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a set of leather gloves which provides no light.
    /// </summary>
    public override int? Radius => 3;
    public override bool? ResLight => true;
    public override bool? SustCon => true;
    public override int? Value => 30000;
    public override string BonusAttacksRollExpression => "10";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
