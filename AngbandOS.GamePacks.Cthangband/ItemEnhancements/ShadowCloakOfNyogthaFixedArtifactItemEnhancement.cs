namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfNyogthaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.RestoreLifeLevelsEvery450DirectionalActivation);
    public override string FriendlyName => "of Nyogtha";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Charisma => "2";
    public override string? Intelligence => "2";
    public override string? Speed => "2";
    public override string? Stealth => "2";
    public override string? Wisdom => "2";
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResFire => true;
    public override int? Value => 55000;
    public override string Attacks => "20";
    public override ColorEnum? Color => ColorEnum.Black;
}
