namespace AngbandOS.Core;
    [Serializable]
internal class ImpactAttribute : OrAttribute
{
    private ImpactAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Impact;
}