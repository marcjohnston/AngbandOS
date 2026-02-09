namespace AngbandOS.Core;
    [Serializable]
internal class CanApplySlayingBonusAttribute : OrAttribute
{
    private CanApplySlayingBonusAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.CanApplySlayingBonus;
}