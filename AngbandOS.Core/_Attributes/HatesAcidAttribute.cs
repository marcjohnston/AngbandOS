namespace AngbandOS.Core;
    [Serializable]
internal class HatesAcidAttribute : OrAttribute
{
    private HatesAcidAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HatesAcid;
}