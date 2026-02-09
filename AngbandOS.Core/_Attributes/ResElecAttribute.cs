namespace AngbandOS.Core;
    [Serializable]
internal class ResElecAttribute : OrAttribute
{
    private ResElecAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResElec;
}