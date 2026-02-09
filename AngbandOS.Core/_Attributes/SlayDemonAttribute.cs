namespace AngbandOS.Core;
    [Serializable]
internal class SlayDemonAttribute : OrAttribute
{
    private SlayDemonAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayDemon;
}