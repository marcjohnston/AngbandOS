namespace AngbandOS.Core;
    [Serializable]
internal class CanProvideSheathOfFireAttribute : OrAttribute
{
    private CanProvideSheathOfFireAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.CanProvideSheathOfFire;
}