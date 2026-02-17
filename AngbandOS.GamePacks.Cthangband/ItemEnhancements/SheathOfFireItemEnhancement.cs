namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SheathOfFireItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
    };
}
