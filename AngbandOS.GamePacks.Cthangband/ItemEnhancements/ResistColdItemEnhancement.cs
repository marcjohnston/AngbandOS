namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistColdItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
