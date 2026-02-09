namespace AngbandOS.Core;
    [Serializable]
internal class ToDamageAttribute : SumAttribute
{
    private ToDamageAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ToDamage;
}