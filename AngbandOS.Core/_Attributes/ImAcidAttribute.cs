namespace AngbandOS.Core;
    [Serializable]
internal class ImAcidAttribute : OrAttribute
{
    private ImAcidAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ImAcid;
}