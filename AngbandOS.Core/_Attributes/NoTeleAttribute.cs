namespace AngbandOS.Core;
    [Serializable]
internal class NoTeleAttribute : OrAttribute
{
    private NoTeleAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.NoTele;
}