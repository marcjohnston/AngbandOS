namespace AngbandOS.Core;
    [Serializable]
internal class BaseArmorClassAttribute : SumAttribute
{
    private BaseArmorClassAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.BaseArmorClass;
}