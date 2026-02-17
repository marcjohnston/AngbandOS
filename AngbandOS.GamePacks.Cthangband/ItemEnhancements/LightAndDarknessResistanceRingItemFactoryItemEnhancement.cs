namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightAndDarknessResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResDark => true;
    public override bool? ResLight => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "3000"),
    };
    public override string? HatesElectricity => "true";
}
