namespace AngbandOS.Core;
    [Serializable]
internal class HatesElectricityAttribute : OrAttribute
{
    private HatesElectricityAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HatesElectricity;
}