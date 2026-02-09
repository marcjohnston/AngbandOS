namespace AngbandOS.Core;
    [Serializable]
internal class ResAcidAttribute : OrAttribute
{
    private ResAcidAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResAcid;
}