namespace AngbandOS.Core;
    [Serializable]
internal class MeleeToHitAttribute : SumAttribute
{
    private MeleeToHitAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.MeleeToHit;
}