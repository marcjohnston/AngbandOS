namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerDragonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfElements300r3DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ResShards => true;
    public override bool ResSound => true;
    public override int TreasureRating => 30;
}