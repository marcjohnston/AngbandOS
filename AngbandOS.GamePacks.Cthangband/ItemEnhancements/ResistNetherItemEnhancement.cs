namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistNetherItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResNether => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
