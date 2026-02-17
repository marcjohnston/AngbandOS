namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EasyKnowIgnoreElementsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "400"),
    };
}
