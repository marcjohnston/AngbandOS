namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfTheDawnFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Dawn Sword summons a reaver
    public override string? ActivationName => nameof(ActivationsEnum.SummonFriendlyReaverEvery500p1d500Activation);
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dawn";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusCharismaRollExpression => "3";
    public override string? BonusInfravisionRollExpression => "3";
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool SustCha => true;
    public override bool Vorpal => true;
}