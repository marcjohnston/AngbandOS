namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistElectricityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResElec => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
