namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearOfDestinyFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.StoneToMudDirectionalActivation);
    public override bool Blessed => true;
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override bool Feather => true;
    public override string FriendlyName => "of Destiny";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool Int => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a spear which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusInfravisionRollExpression => "4";
    public override string? BonusIntelligenceRollExpression => "4";
    public override string? BonusWisdomRollExpression => "4";
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayUndead => true;
    public override bool Wis => true;
}