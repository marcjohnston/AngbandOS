namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowOfSerpentsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "3";
    public override bool ShowMods => true;
    public override bool XtraMight => true;
}