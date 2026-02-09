namespace AngbandOS.Core;
    [Serializable]
internal class ArtifactBiasAttribute : NullableReferenceAttribute<ArtifactBias>
{
    private ArtifactBiasAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ArtifactBias;
}