namespace AngbandOS.Core;
    [Serializable]
internal class ImFireAttribute : OrAttribute
{
    private ImFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ImFire;
}