namespace AngbandOS.Core;
    [Serializable]
internal class TeleportAttribute : OrAttribute
{
    private TeleportAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Teleport;
}