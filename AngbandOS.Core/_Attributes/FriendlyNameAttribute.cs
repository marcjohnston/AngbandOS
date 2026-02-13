namespace AngbandOS.Core;
    [Serializable]
internal class FriendlyNameAttribute : StringNullableReferenceAttribute
{
    private FriendlyNameAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.FriendlyName;
}