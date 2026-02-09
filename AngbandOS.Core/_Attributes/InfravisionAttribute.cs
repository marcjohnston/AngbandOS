namespace AngbandOS.Core;
    [Serializable]
internal class InfravisionAttribute : SumAttribute
{
    private InfravisionAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Infravision;
}