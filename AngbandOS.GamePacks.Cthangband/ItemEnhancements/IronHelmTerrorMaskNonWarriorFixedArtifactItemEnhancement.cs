namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskNonWarriorFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? HeavyCurse => true;
    public override bool? Aggravate => true;
    public override bool? DreadCurse => true;
    public override bool? Valueless => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "-42500"),
    };
}
