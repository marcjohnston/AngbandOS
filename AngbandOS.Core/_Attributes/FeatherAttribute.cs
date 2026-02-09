namespace AngbandOS.Core;
    [Serializable]
internal class FeatherAttribute : OrAttribute
{
    private FeatherAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Feather;
}