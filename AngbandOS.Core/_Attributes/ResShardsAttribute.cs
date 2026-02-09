namespace AngbandOS.Core;
    [Serializable]
internal class ResShardsAttribute : OrAttribute
{
    private ResShardsAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResShards;
}