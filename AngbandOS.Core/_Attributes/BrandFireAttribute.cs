namespace AngbandOS.Core;
    [Serializable]
internal class BrandFireAttribute : OrAttribute
{
    private BrandFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.BrandFire;
}