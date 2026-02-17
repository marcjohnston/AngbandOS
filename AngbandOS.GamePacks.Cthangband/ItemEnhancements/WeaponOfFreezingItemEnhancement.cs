namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfFreezingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "15"),
    };
    public override string? FriendlyName => "of Freezing";
    public override bool? IgnoreCold => true;
    public override bool? ResCold => true;
    }
