namespace AngbandOS.Core;
    [Serializable]
internal class BlowsAttribute : OrAttribute
{
    private BlowsAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Blows;
}