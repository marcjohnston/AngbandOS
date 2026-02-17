namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RegenerationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Regen => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
