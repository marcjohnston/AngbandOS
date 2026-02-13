namespace AngbandOS.Core;
    [Serializable]
internal class ArtifactBiasAttribute : ArtifactBiasNullableReferenceAttribute
{
    private ArtifactBiasAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ArtifactBias;
}