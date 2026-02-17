namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfFreeActionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(TreasureRatingAttribute), "11"),
    };
    public override bool? FreeAct => true;
    public override string? FriendlyName => "of Free Action";
}
