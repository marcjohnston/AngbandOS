
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class OpenBraceSymbol : Symbol
{
    private OpenBraceSymbol(Game game) : base(game) { }
    public override char Character => '[';
    public override string Name => "Hard armor";
}

