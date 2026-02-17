namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayEvilItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayEvil => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
    };
}
