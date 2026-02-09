namespace AngbandOS.Core;
    [Serializable]
internal class Vorpal1InChanceAttribute : SumAttribute
{
    private Vorpal1InChanceAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Vorpal1InChance;
}