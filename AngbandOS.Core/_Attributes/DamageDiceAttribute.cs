namespace AngbandOS.Core;
    [Serializable]
internal class DamageDiceAttribute : SumAttribute
{
    private DamageDiceAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.DamageDice;
}