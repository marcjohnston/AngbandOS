namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfRegenerationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1500"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Regeneration";
    public override bool? Regen => true;
    }
