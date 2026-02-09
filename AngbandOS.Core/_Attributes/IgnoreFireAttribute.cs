namespace AngbandOS.Core;
    [Serializable]
internal class IgnoreFireAttribute : OrAttribute
{
    private IgnoreFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.IgnoreFire;
}