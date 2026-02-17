namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponChaoticItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Chaotic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
        (nameof(TreasureRatingAttribute), "28"),
    };
    public override string? FriendlyName => "(Chaotic)";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResChaos => true;
    }
