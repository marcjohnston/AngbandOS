namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerBSymbol : Symbol
{
    private LowerBSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'b';
    public override string Name => "Bat";
}
