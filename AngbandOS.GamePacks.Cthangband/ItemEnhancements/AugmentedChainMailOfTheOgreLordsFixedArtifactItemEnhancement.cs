namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailOfTheOgreLordsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Ogre Lords destroys doors
    public override string? ActivationName => nameof(ActivationsEnum.DestroyDoorsEvery10Activation);
    public override string FriendlyName => "of the Ogre Lords";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Constitution => "3";
    public override string? Intelligence => "3";
    public override string? Wisdom => "3";
    public override bool? ResAcid => true;
    public override bool? ResConf => true;
    public override bool? ResPois => true;
    public override int? Value => 40000;
    public override string Attacks => "20";
    public override string Hits => "-2";
    public override ColorEnum? Color => ColorEnum.Grey;
}
