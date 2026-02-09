namespace AngbandOS.Core;
    [Serializable]
internal class CanProvideSheathOfElectricityAttribute : OrAttribute
{
    private CanProvideSheathOfElectricityAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.CanProvideSheathOfElectricity;
}