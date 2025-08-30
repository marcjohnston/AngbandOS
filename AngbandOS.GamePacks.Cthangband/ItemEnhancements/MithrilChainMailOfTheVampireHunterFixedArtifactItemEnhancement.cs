namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilChainMailOfTheVampireHunterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Vampire Hunter cures most ailments
    public override string? ActivationName => nameof(ActivationsEnum.Heal777CuringAndHeroism25pd25Every300Activation);
    public override int? TreasureRating => 20;
    public override string FriendlyName => "of the Vampire Hunter";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Intelligence => "4";
    public override string? Stealth => "4";
    public override string? Wisdom => "4";
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResElec => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ResNether => true;
    public override bool? ResPois => true;
    public override bool? SeeInvis => true;
    public override int? Value => 135000;
    public override string Attacks => "20";
    public override string Hits => "-1";
    public override ColorEnum? Color => ColorEnum.BrightBlue;
}
