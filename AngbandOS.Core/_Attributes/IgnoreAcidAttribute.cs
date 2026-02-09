namespace AngbandOS.Core;
    [Serializable]
internal class IgnoreAcidAttribute : OrAttribute
{
    private IgnoreAcidAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.IgnoreAcid;
}