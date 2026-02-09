namespace AngbandOS.Core;
    [Serializable]
internal class HeavyCurseAttribute : BoolAttribute
{
    private HeavyCurseAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.HeavyCurse;
}