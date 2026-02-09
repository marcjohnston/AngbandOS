namespace AngbandOS.Core;
    [Serializable]
internal class ResFearAttribute : OrAttribute
{
    private ResFearAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResFear;
}