namespace AngbandOS.Core;
    [Serializable]
internal class TunnelAttribute : SumAttribute
{
    private TunnelAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Tunnel;
}