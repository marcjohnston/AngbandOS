namespace AngbandOS.Core;
    [Serializable]
internal class ActivationAttribute : ActivationNullableReferenceAttribute
{
    private ActivationAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Activation;
}