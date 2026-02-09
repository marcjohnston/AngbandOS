namespace AngbandOS.Core;
    [Serializable]
internal class DisarmTrapsAttribute : SumAttribute
{
    private DisarmTrapsAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.DisarmTraps;
}