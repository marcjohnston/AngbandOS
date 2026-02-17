namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayOrcItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayOrc => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3000"),
    };
}
