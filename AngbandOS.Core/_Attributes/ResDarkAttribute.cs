namespace AngbandOS.Core;
    [Serializable]
internal class ResDarkAttribute : OrAttribute
{
    private ResDarkAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResDark;
}