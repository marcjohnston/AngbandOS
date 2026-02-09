namespace AngbandOS.Core;
    [Serializable]
internal class IgnoreElecAttribute : OrAttribute
{
    private IgnoreElecAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.IgnoreElec;
}