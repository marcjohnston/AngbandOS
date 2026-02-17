namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistAcidItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResAcid => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
