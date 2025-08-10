namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NecklaceOfTheDwarvesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dwarves";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a radius of 3 for this fixed artifact.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusStrengthRollExpression => "3";
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override int Cost => 75000;
}
