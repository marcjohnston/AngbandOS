namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistDarknessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResDark => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1750"),
    };
}
