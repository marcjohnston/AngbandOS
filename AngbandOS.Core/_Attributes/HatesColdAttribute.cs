namespace AngbandOS.Core;
    [Serializable]
internal class HatesColdAttribute : OrAttribute
{
    private HatesColdAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HatesCold;
}