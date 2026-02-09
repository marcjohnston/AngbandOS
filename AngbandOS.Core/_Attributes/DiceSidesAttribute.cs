namespace AngbandOS.Core;
    [Serializable]
internal class DiceSidesAttribute : SumAttribute
{
    private DiceSidesAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.DiceSides;
}