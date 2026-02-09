namespace AngbandOS.Core;
    [Serializable]
internal class AntiTheftAttribute : OrAttribute
{
    private AntiTheftAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.AntiTheft;
}