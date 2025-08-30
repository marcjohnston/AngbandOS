namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerStormFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Ring of Elemental Lightning casts a lightning ball
    public override string? ActivationName => nameof(ActivationsEnum.LargeLightningBall250Every425p1d425DirectionalActivation);
    public override int? TreasureRating => 20;
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Storm)";
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImElec => true;
    public override string? Charisma => "3";
    public override string? Constitution => "3";
    public override string? Dexterity => "3";
    public override string? Intelligence => "3";
    public override string? Speed => "3";
    public override string? Strength => "3";
    public override string? Wisdom => "3";
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? SlowDigest => true;
    public override bool? SustDex => true;
    public override bool? SustInt => true;
    public override bool? SustStr => true;
    public override bool? SustWis => true;
    public override int? Radius => 3;
    public override bool? Telepathy => true;
    public override int? Value => 300000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override string Hits => "12";
    public override string Damage => "12";
}
