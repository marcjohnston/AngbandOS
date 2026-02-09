namespace AngbandOS.Core;
    [Serializable]
internal class ThrowingToHitAttribute : SumAttribute
{
    private ThrowingToHitAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ThrowingToHit;
}