namespace AngbandOS.Core;
    [Serializable]
internal class ResChaosAttribute : OrAttribute
{
    private ResChaosAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResChaos;
}