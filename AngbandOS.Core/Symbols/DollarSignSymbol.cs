namespace AngbandOS.Core.Symbols;

[Serializable]
internal class DollarSignSymbol : Symbol
{
    private DollarSignSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '$';
    public override string Name => "Treasure (gold or gems)";
}
