namespace AngbandOS.Core;
    [Serializable]
internal class CanApplyBlowsBonusAttribute : OrAttribute
{
    private CanApplyBlowsBonusAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.CanApplyBlowsBonus;
}