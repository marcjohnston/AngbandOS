namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfTheSwashbucklerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Swashbuckler recharges items
    public override string? ActivationName => nameof(ActivationsEnum.RechargeActivation);
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Swashbuckler";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusCharismaRollExpression => "3";
    public override string? BonusDexterityRollExpression => "3";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override int Value => 35000;
    public override string BonusAttacksRollExpression => "18";
    public override ColorEnum? Color => ColorEnum.Green;
}
