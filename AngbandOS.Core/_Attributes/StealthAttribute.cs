namespace AngbandOS.Core;
    [Serializable]
internal class StealthAttribute : SumAttribute
{
    private StealthAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Stealth;
}