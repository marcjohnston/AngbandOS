namespace AngbandOS.Core;
    [Serializable]
internal class ImElecAttribute : OrAttribute
{
    private ImElecAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ImElec;
}