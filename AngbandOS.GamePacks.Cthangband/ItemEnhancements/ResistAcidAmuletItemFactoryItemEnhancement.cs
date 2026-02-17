namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistAcidAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? IgnoreAcid => true;
    public override bool? ResAcid => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "300"),
    };
}
