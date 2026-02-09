namespace AngbandOS.Core;
    [Serializable]
internal class SlayEvilAttribute : OrAttribute
{
    private SlayEvilAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayEvil;
}