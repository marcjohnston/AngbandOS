namespace AngbandOS.Core;
    [Serializable]
internal class ResFireAttribute : OrAttribute
{
    private ResFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResFire;
}