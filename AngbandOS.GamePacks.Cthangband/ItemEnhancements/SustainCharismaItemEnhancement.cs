namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainCharismaItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SustCha => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "250"),
    };
}
