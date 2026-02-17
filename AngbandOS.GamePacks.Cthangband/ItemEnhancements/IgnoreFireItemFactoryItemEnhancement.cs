namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IgnoreFireItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreFire => true;
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "100"),
    };
}
