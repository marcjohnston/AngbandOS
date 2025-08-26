namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TridentOfWrathFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Blessed => true;
    public override bool Chaotic => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Wrath";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int Weight => 230;
    public override int Value => 90000;
    public override int DamageDice => 2;
    public override string BonusHitsRollExpression => "16";
    public override string BonusDamageRollExpression => "18";
    public override ColorEnum Color => ColorEnum.Yellow;
}
