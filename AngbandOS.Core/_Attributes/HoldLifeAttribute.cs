namespace AngbandOS.Core;
    [Serializable]
internal class HoldLifeAttribute : OrAttribute
{
    private HoldLifeAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HoldLife;
}