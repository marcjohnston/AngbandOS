namespace AngbandOS.Core;
    [Serializable]
internal class SlayUndeadAttribute : OrAttribute
{
    private SlayUndeadAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayUndead;
}