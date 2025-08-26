namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfKarakalFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Karakal teleports you randomly
    public override string? ActivationName => nameof(ActivationsEnum.GetawayEvery35Activation);
    public override bool BrandElec => true;
    public override bool Chaotic => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Karakal";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusAttacksRollExpression => "2";
    public override string? BonusConstitutionRollExpression => "2";
    public override string? BonusSpeedRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool Regen => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool SustCon => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int Value => 150000;
    public override string BonusHitsRollExpression => "8";
    public override string BonusDamageRollExpression => "12";
    public override ColorEnum Color => ColorEnum.BrightWhite;
}
