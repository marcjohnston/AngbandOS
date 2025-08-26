namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Dragon Helm and Terror Mask cause fear
    public override string? ActivationName => nameof(ActivationsEnum.Terror40xEvery3xp10Activation);
    public override bool FreeAct => true;
    public override string FriendlyName => "'Terror Mask'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool NoMagic => true;
    public override string? BonusIntelligenceRollExpression => "-1";
    public override string? BonusSearchRollExpression => "-1";
    public override string? BonusWisdomRollExpression => "-1";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Teleport => true;
    public override int Value => 40000;
    public override string BonusAttacksRollExpression => "10";
    public override string BonusHitsRollExpression => "25";
    public override string BonusDamageRollExpression => "25";
    public override ColorEnum Color => ColorEnum.Grey;
}
