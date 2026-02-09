namespace AngbandOS.Core;
    [Serializable]
internal class ShElecAttribute : OrAttribute
{
    private ShElecAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ShElec;
}