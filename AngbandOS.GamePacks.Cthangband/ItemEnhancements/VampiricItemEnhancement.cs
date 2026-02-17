namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VampiricItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Vampiric => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "13000"),
    };
}
