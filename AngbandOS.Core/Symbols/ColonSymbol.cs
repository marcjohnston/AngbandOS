
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class ColonSymbol : Symbol
{
    private ColonSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ':';
    public override string Name => "Rubble";
}

