namespace AngbandOS.Core;
    [Serializable]
internal class RegenAttribute : OrAttribute
{
    private RegenAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Regen;
}