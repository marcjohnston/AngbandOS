namespace AngbandOS.Core;
    [Serializable]
internal class IntelligenceAttribute : SumAttribute
{
    private IntelligenceAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Intelligence;
}