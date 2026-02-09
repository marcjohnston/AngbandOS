namespace AngbandOS.Core;
    [Serializable]
internal class StrengthAttribute : SumAttribute
{
    private StrengthAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Strength;
}