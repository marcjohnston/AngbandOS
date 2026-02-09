namespace AngbandOS.Core;
    [Serializable]
internal class ReflectAttribute : OrAttribute
{
    private ReflectAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Reflect;
}