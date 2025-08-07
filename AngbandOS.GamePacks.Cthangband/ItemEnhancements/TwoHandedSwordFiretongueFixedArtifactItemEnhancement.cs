namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordFiretongueFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Firetongue'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool KillDragon => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a two-handed sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusCharismaRollExpression => "4";
    public override string? BonusStrengthRollExpression => "4";
    public override bool ResChaos => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override bool Vorpal => true;
    public override int Weight => 50;
    public override int Cost => 205000;
}
