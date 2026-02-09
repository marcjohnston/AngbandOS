namespace AngbandOS.Core;
    [Serializable]
internal class DrainExpAttribute : OrAttribute
{
    private DrainExpAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.DrainExp;
}