
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class OpenBraceSymbol : Symbol
{
    private OpenBraceSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '[';
    public override string Name => "Hard armor";
}

