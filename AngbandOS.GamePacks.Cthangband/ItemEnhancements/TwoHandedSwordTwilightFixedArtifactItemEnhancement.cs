namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordTwilightFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override bool IsCursed => true;
    public override bool DreadCurse => true;
    public override string FriendlyName => "'Twilight'";
    public override bool HeavyCurse => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a two-handed sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusSpeedRollExpression => "10";
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int Weight => 50;
    public override int Cost => 40000;
    public override int DamageDice => 1;
}
