namespace AngbandOS.Core;
    [Serializable]
internal class SlowDigestAttribute : OrAttribute
{
    private SlowDigestAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlowDigest;
}