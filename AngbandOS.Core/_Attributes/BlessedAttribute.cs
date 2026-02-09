namespace AngbandOS.Core;
    [Serializable]
internal class BlessedAttribute : OrAttribute
{
    private BlessedAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Blessed;
}