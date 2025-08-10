namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfThanosFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Aggravate => true;
    public override bool IsCursed => true;
    public override bool DreadCurse => true;
    public override string FriendlyName => "of Thanos";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool ImFire => true;
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ShowMods => true;
    public override bool Teleport => true;
    public override int Cost => 40000;
    public override string BonusHitRollExpression => "-11";
    public override string BonusDamageRollExpression => "-12";
}
