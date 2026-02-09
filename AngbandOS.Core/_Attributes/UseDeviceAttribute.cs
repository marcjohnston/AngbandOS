namespace AngbandOS.Core;
    [Serializable]
internal class UseDeviceAttribute : SumAttribute
{
    private UseDeviceAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.UseDevice;
}