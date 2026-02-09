namespace AngbandOS.Core;
    [Serializable]
internal class ShFireAttribute : OrAttribute
{
    private ShFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ShFire;
}