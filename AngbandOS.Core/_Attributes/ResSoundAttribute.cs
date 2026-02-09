namespace AngbandOS.Core;
    [Serializable]
internal class ResSoundAttribute : OrAttribute
{
    private ResSoundAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResSound;
}