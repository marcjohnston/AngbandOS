namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayAnimalItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayAnimal => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
