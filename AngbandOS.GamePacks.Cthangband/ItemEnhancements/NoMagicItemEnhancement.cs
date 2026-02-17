namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NoMagicItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? NoMagic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
