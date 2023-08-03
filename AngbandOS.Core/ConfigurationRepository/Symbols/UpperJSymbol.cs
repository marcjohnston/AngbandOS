
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperJSymbol : Symbol
{
    private UpperJSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'J';
    public override string Name => "Snake";
}

