namespace AngbandOS.Core;
    [Serializable]
internal class ColorAttribute : ColorEnumAttribute
{
    private ColorAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Color;
}