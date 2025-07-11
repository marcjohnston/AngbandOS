namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesCalfskinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Con => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Calfskin'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool ShowMods => true;
    public override bool Str => true;
}