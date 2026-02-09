namespace AngbandOS.Core;
    [Serializable]
internal class CharismaAttribute : SumAttribute
{
    private CharismaAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Charisma;
}