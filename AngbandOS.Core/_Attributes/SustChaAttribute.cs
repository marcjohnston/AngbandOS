namespace AngbandOS.Core;
    [Serializable]
internal class SustChaAttribute : OrAttribute
{
    private SustChaAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SustCha;
}