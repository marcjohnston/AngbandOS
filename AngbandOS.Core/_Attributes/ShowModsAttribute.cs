namespace AngbandOS.Core;
    [Serializable]
internal class ShowModsAttribute : OrAttribute
{
    private ShowModsAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ShowMods;
}