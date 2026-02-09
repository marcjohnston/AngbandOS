namespace AngbandOS.Core;
    [Serializable]
internal class IsCursedAttribute : BoolAttribute
{
    private IsCursedAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.IsCursed;
}