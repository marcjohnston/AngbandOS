namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayOrcItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Slay Orc";
    public override bool? SlayOrc => true;
    }
