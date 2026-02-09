namespace AngbandOS.Core;
    [Serializable]
internal class BonusArmorClassAttribute : SumAttribute
{
    private BonusArmorClassAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.BonusArmorClass;
}