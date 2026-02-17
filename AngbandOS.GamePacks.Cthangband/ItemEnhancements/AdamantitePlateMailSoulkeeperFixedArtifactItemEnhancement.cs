namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AdamantitePlateMailSoulkeeperFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Heal1000Every888Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "280000"),        (nameof(AttacksAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-4"),
        (nameof(ConstitutionAttribute), "2"),
    };
    public override string FriendlyName => "'Soulkeeper'";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResChaos => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResNether => true;
    public override bool? ResNexus => true;
    public override bool? SustCon => true;
    public override ColorEnum? Color => ColorEnum.BrightGreen;
}
