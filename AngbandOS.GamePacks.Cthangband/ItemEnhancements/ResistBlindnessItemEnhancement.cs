namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistBlindnessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResBlind => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
