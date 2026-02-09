namespace AngbandOS.Core;
    [Serializable]
internal class ResLightAttribute : OrAttribute
{
    private ResLightAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResLight;
}