
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerHSymbol : Symbol
{
    private LowerHSymbol(Game game) : base(game) { }
    public override char Character => 'h';
    public override string Name => "Hobbit/Elf/Dwarf";
}

