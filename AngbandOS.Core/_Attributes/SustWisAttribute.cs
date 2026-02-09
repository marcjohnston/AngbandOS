namespace AngbandOS.Core;
    [Serializable]
internal class SustWisAttribute : OrAttribute
{
    private SustWisAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SustWis;
}