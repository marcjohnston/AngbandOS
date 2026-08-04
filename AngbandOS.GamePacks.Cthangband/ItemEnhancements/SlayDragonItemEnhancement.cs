namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayDragonItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SlayDragonAttribute), "3"),
        (nameof(ValueAttribute), "4500"),
    };
}
