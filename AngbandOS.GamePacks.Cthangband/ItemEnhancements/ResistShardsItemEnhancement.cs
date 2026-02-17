namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistShardsItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResShards => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
