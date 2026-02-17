namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistLightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResLight => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1750"),
    };
}
