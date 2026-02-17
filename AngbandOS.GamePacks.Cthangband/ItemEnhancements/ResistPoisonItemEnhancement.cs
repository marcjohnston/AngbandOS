namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistPoisonItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
