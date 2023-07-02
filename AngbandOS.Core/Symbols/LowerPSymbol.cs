
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerPSymbol : Symbol
{
    private LowerPSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'p';
    public override string Name => "Person/Human";
}

