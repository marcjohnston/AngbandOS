
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerHSymbol : Symbol
{
    private LowerHSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'h';
    public override string Name => "Hobbit/Elf/Dwarf";
}

