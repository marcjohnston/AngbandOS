namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfCestiOfCombatFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.MagicalArrow150Every1d90p90DirectionalActivation);
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Combat";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "4";
    public override bool ResAcid => true;
    public override bool ShowMods => true;
    public override bool Feather => true;
    public override bool HoldLife => true;
    public override int Radius => 3;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int Value => 110000;
    public override string BonusAttacksRollExpression => "20";
    public override string BonusHitsRollExpression => "10";
    public override string BonusDamageRollExpression => "10";
    public override ColorEnum Color => ColorEnum.BrightWhite;
}
