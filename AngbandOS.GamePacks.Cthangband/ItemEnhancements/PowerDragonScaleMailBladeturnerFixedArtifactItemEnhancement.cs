namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerDragonScaleMailBladeturnerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.PowerDragonEvery400DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-8"),
        (nameof(AttacksAttribute), "35"),
        (nameof(ValueAttribute), "500000"),
        (nameof(WeightAttribute), "350"),
        (nameof(BonusArmorClassAttribute), "10"),    
    };
    public override bool? Feather => true;
    public override string FriendlyName => "'Bladeturner'";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResAcid => true;
    public override bool? ResBlind => true;
    public override bool? ResChaos => true;
    public override bool? ResCold => true;
    public override bool? ResConf => true;
    public override bool? ResDark => true;
    public override bool? ResDisen => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ResNether => true;
    public override bool? ResNexus => true;
    public override bool? ResPois => true;
    public override bool? ResShards => true;
    public override bool? ResSound => true;
    public override ColorEnum? Color => ColorEnum.Purple;
    public override bool? HideType => true;
}
