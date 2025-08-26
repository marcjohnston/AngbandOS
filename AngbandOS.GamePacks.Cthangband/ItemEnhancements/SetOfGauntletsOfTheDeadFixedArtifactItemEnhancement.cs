namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfTheDeadFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfAcid5d8Every1d5p5DirectionalActivation);
    public override string FriendlyName => "of the Dead";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResAcid => true;
    public override int Value => 12000;
    public override string BonusAttacksRollExpression => "15";
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
