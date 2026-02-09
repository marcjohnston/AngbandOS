namespace AngbandOS.Core;
    [Serializable]
internal class SustIntAttribute : OrAttribute
{
    private SustIntAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SustInt;
}