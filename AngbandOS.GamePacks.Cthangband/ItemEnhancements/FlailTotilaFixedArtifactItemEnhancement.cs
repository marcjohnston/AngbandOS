namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlailTotilaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Totila does confusion
    public override string? ActivationName => nameof(ActivationsEnum.ConfuseMonster20Every15DirectionalActivation);
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Totila'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a flail which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusStealthRollExpression => "2";
    public override bool ResConf => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override int Value => 55000;
    public override int DamageDice => 1;
    public override string BonusHitsRollExpression => "6";
    public override string BonusDamageRollExpression => "8";
    public override ColorEnum Color => ColorEnum.Black;
}
