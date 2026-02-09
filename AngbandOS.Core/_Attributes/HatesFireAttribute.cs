namespace AngbandOS.Core;
    [Serializable]
internal class HatesFireAttribute : OrAttribute
{
    private HatesFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HatesFire;
}