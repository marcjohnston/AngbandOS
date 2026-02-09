namespace AngbandOS.Core;
    [Serializable]
internal class SeeInvisAttribute : OrAttribute
{
    private SeeInvisAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SeeInvis;
}