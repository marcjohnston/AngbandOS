namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperHSymbol : Symbol
{
    private UpperHSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'H';
    public override string Name => "Hybrid";
}
