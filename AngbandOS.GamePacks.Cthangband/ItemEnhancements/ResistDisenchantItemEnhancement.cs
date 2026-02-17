namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistDisenchantItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResDisen => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
