namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakShifterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Shifter teleports you
    public override string? ActivationName => nameof(ActivationsEnum.Teleport100Every45Activation);
    public override string FriendlyName => "'Shifter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusStealthRollExpression => "3";
    public override bool ResAcid => true;
    public override bool Stealth => true;
}