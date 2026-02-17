namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfVitriolItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandAcid => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "8000"),
        (nameof(TreasureRatingAttribute), "15"),
    };
    public override string? FriendlyName => "of Vitriol";
    public override bool? IgnoreAcid => true;
    public override bool? ResAcid => true;
    }
