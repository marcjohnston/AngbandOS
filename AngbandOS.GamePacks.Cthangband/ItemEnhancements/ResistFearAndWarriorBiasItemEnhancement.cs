namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistFearAndWarriorBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResFear => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Warrior1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
