namespace AngbandOS.Core;
    [Serializable]
internal class ArtifactBiasSlayingDisabledAttribute : OrAttribute
{
    private ArtifactBiasSlayingDisabledAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ArtifactBiasSlayingDisabled;
}