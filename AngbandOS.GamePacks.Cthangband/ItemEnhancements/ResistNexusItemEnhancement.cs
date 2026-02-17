namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistNexusItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResNexus => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
