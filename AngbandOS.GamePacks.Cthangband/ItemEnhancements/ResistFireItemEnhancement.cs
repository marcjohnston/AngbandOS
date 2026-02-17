namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistFireItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
