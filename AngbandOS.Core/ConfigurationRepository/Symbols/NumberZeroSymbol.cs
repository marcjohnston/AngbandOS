namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberZeroSymbol : Symbol
{
    private NumberZeroSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '0';
    public override string Name => "Entrance to Pawnbrokers";
}
