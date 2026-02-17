namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfPoisoningItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Poisoning";
    public override bool? ResPois => true;
    }
