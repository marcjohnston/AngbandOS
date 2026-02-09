namespace AngbandOS.Core;
    [Serializable]
internal class BrandElecAttribute : OrAttribute
{
    private BrandElecAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.BrandElec;
}