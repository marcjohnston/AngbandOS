namespace AngbandOS.Core;
    [Serializable]
internal class HideTypeAttribute : OrAttribute
{
    private HideTypeAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HideType;
}