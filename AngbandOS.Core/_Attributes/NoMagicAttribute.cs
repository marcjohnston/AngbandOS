namespace AngbandOS.Core;
    [Serializable]
internal class NoMagicAttribute : OrAttribute
{
    private NoMagicAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.NoMagic;
}