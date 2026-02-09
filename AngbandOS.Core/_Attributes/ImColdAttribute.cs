namespace AngbandOS.Core;
    [Serializable]
internal class ImColdAttribute : OrAttribute
{
    private ImColdAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ImCold;
}