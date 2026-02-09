namespace AngbandOS.Core;
    [Serializable]
internal class VorpalExtraAttacks1InChanceAttribute : SumAttribute
{
    private VorpalExtraAttacks1InChanceAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.VorpalExtraAttacks1InChance;
}