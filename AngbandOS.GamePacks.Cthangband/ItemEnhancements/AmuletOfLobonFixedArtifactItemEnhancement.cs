namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfLobonFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Amulet of Lobon protects us from evil
    public override string? ActivationName => nameof(ActivationsEnum.ProtectionFromEvilActivation);
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Lobon";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override string? BonusConstitutionRollExpression => "2";
    public override bool ResFire => true;
}