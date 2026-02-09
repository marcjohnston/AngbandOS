namespace AngbandOS.Core;
    [Serializable]
internal class ResDisenAttribute : OrAttribute
{
    private ResDisenAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResDisen;
}