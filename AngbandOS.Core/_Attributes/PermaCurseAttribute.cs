namespace AngbandOS.Core;
    [Serializable]
internal class PermaCurseAttribute : OrAttribute
{
    private PermaCurseAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.PermaCurse;
}