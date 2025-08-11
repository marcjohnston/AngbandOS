namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalScaleMailOfTheOrcsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Orc does Carnage
    public override string? BonusArmorClassRollExpression => "2"; // 13 -> 15
    public override string? ActivationName => nameof(ActivationsEnum.GenocideEvery500Activation);
    public override int TreasureRating => 20;
    public override string FriendlyName => "of the Orcs";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusCharismaRollExpression => "4";
    public override string? BonusStrengthRollExpression => "4";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override int Cost => 150000;
    public override int DamageDice => 1;
    public override string BonusAttacksRollExpression => "40";
    public override string BonusHitsRollExpression => "-2";
    public override ColorEnum Color => ColorEnum.Grey;
}
