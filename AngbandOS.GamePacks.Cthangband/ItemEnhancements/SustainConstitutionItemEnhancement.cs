namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainConstitutionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SustCon => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "850"),
    };
}
