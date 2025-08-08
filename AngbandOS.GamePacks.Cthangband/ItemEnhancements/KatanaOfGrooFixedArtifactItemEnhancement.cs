namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KatanaOfGrooFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Blows => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Groo";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusAttacksRollExpression => "3";
    public override string? BonusDexterityRollExpression => "3";
    public override string? BonusSpeedRollExpression => "3";
    public override bool ShowMods => true;
    public override bool SustDex => true;
    public override bool Vorpal => true;
    public override int Weight => -70;
    public override int Cost => 75000;
}
