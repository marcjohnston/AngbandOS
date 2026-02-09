namespace AngbandOS.Core;
    [Serializable]
internal class RangedToHitAttribute : SumAttribute
{
    private RangedToHitAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.RangedToHit;
}