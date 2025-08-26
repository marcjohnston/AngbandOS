namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfHardLeatherBootsOfIthaquaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Boots haste you
    public override string? ActivationName => nameof(ActivationsEnum.Speed20p1d20Every200Activation);
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Ithaqua";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusSpeedRollExpression => "15";
    public override bool ResNexus => true;
    public override int Value => 300000;
    public override string BonusAttacksRollExpression => "20";
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
