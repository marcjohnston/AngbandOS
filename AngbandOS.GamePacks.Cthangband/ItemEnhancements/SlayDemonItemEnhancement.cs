namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayDemonItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayDemon => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
