namespace AngbandOS.Core;
    [Serializable]
internal class ResConfAttribute : OrAttribute
{
    private ResConfAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResConf;
}