namespace AngbandOS.Core;
    [Serializable]
internal class RadiusAttribute : SumAttribute
{
    private RadiusAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Radius;
}