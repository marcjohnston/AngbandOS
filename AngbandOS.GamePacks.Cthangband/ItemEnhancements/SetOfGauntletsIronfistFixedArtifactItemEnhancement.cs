namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsIronfistFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfFire9d8Every1d8p8DirectionalActivation);
    public override string FriendlyName => "'Ironfist'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override int? Value => 15000;
    public override string BonusAttacksRollExpression => "15";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
