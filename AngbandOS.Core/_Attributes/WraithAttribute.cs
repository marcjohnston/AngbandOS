namespace AngbandOS.Core;
    [Serializable]
internal class WraithAttribute : OrAttribute
{
    private WraithAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Wraith;
}