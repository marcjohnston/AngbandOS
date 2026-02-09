namespace AngbandOS.Core;
    [Serializable]
internal class FreeActAttribute : OrAttribute
{
    private FreeActAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.FreeAct;
}