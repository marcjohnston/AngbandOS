namespace AngbandOS.Core;
    [Serializable]
internal class TelepathyAttribute : OrAttribute
{
    private TelepathyAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Telepathy;
}