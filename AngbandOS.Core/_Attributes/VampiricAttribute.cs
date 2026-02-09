namespace AngbandOS.Core;
    [Serializable]
internal class VampiricAttribute : OrAttribute
{
    private VampiricAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Vampiric;
}