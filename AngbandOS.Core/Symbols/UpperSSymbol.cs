
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperSSymbol : Symbol
{
    private UpperSSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'S';
    public override string Name => "Spider/Scorpion/Tick";
}

