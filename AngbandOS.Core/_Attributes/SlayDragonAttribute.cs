namespace AngbandOS.Core;
    [Serializable]
internal class SlayDragonAttribute : SumAttribute
{
    private SlayDragonAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayDragon;
}