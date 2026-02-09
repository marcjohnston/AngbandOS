namespace AngbandOS.Core;
    [Serializable]
internal class SavingThrowAttribute : SumAttribute
{
    private SavingThrowAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SavingThrow;
}