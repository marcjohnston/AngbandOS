namespace AngbandOS.Core;
    [Serializable]
internal class SustDexAttribute : OrAttribute
{
    private SustDexAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SustDex;
}