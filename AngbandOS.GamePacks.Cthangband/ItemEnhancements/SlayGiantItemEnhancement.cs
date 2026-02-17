namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayGiantItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayGiant => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
