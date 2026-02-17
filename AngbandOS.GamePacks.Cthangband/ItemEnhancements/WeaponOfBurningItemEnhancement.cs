namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfBurningItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? FriendlyName => "of Burning";
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    }
