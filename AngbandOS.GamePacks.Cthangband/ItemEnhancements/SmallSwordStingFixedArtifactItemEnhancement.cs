namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallSwordStingFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Blows => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Sting'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a small sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayUndead => true;
    public override int Weight => -5;
    public override int Cost => 100000;
    public override int DiceSides => -1;
    public override string BonusHitRollExpression => "7";
    public override string BonusDamageRollExpression => "8";
}
