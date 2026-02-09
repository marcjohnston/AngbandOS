namespace AngbandOS.Core;
    [Serializable]
internal class AttacksAttribute : SumAttribute
{
    private AttacksAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Attacks;
}