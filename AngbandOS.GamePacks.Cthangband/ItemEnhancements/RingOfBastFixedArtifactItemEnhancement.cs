namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfBastFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Ring of Bast hastes you
    public override string? ActivationName => nameof(ActivationsEnum.Speed75p1d75Every150p1d150Activation);
    public override int? TreasureRating => 20;
    public override string FriendlyName => "of Bast";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Constitution => "4";
    public override string? Dexterity => "4";
    public override string? Speed => "4";
    public override string? Strength => "4";
    public override int? Value => 175000;
}
