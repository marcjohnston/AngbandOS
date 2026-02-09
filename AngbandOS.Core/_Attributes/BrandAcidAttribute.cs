namespace AngbandOS.Core;
    [Serializable]
internal class BrandAcidAttribute : OrAttribute
{
    private BrandAcidAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.BrandAcid;
}