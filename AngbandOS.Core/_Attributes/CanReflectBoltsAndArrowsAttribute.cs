namespace AngbandOS.Core;
    [Serializable]
internal class CanReflectBoltsAndArrowsAttribute : OrAttribute
{
    private CanReflectBoltsAndArrowsAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.CanReflectBoltsAndArrows;
}