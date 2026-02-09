namespace AngbandOS.Core;
    [Serializable]
internal class SpeedAttribute : SumAttribute
{
    private SpeedAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Speed;
}