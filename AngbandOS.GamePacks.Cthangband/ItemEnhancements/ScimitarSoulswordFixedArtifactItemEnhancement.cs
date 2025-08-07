namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScimitarSoulswordFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Blessed => true;
    public override bool Blows => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Soulsword'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Wis => true;
    public override int Cost => 111111;
}
