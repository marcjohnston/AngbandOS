namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistConfusionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResConf => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
