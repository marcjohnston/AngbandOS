namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistFearItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResFear => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
