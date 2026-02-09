namespace AngbandOS.Core;
    [Serializable]
internal class CanApplyBonusArmorClassMiscPowerAttribute : OrAttribute
{
    private CanApplyBonusArmorClassMiscPowerAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.CanApplyBonusArmorClassMiscPower;
}