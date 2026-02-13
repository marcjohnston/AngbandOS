namespace AngbandOS.Core;

[Serializable]
internal class IgnoreColdAttribute : OrAttribute
{
    private IgnoreColdAttribute(Game game) : base(game) { }
}