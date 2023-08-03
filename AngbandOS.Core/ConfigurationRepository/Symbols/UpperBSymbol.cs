
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperBSymbol : Symbol
{
    private UpperBSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'B';
    public override string Name => "Bird";
}

