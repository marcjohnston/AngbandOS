namespace AngbandOS.Core;
    [Serializable]
internal class ResNetherAttribute : OrAttribute
{
    private ResNetherAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResNether;
}