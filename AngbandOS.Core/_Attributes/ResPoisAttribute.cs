namespace AngbandOS.Core;
    [Serializable]
internal class ResPoisAttribute : OrAttribute
{
    private ResPoisAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResPois;
}