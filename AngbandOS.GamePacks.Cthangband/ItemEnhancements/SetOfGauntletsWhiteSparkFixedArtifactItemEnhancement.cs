namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsWhiteSparkFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfElectricity4d8Every1d6p6DirectionalActivation);
    public override string FriendlyName => "'White Spark'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResElec => true;
    public override int Value => 11000;
    public override string BonusAttacksRollExpression => "15";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
