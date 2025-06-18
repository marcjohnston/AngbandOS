namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfCestiOfCombatFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.MagicalArrow150Every1d90p90DirectionalActivation);
    public override int TreasureRating => 20;
    public override bool Dex => true;
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
}