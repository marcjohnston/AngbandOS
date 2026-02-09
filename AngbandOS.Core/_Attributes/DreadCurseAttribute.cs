namespace AngbandOS.Core;
    [Serializable]
internal class DreadCurseAttribute : OrAttribute
{
    private DreadCurseAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.DreadCurse;
}