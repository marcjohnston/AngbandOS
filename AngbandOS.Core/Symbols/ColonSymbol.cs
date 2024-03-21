
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class ColonSymbol : Symbol
{
    private ColonSymbol(Game game) : base(game) { }
    public override char Character => ':';
    public override string Name => "Rubble";
}

