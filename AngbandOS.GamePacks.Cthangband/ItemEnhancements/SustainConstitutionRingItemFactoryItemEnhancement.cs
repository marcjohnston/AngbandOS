namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainConstitutionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SustCon => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "750"),
    };
    public override string? HatesElectricity => "true";
}
