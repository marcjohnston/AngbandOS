namespace AngbandOS.Core;
    [Serializable]
internal class EasyKnowAttribute : OrAttribute
{
    private EasyKnowAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.EasyKnow;
}