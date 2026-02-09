namespace AngbandOS.Core;
    [Serializable]
internal class BrandColdAttribute : OrAttribute
{
    private BrandColdAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.BrandCold;
}