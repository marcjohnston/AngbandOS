namespace AngbandOS.Core;
    [Serializable]
internal class DexterityAttribute : SumAttribute
{
    private DexterityAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Dexterity;
}