
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UnderscoreSymbol : Symbol
{
    private UnderscoreSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '_';
    public override string Name => "A staff";
}

