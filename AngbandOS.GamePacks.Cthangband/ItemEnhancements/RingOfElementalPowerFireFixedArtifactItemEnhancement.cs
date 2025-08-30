namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerFireFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Ring of Elemental Fire casts a fireball
    public override string? ActivationName => nameof(ActivationsEnum.FireBall120r3Every225p1d225DirectionalActivation);
    public override int? TreasureRating => 20;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Fire)";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImFire => true;
    public override string? Charisma => "1";
    public override string? Constitution => "1";
    public override string? Dexterity => "1";
    public override string? Intelligence => "1";
    public override string? Speed => "1";
    public override string? Strength => "1";
    public override string? Wisdom => "1";
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? SlowDigest => true;
    public override bool? SustDex => true;
    public override bool? SustStr => true;
    public override int? Value => 100000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override string Hits => "10";
    public override string Damage => "10";
}
