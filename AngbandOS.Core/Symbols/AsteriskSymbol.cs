
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class AsteriskSymbol : Symbol
{
    private AsteriskSymbol(Game game) : base(game) { }
    public override char Character => '*';
    public override string Name => "A vein with treasure/elder sign or a bush";
}

