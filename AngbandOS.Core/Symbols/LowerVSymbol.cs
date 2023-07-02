namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerVSymbol : Symbol
{
    private LowerVSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'v';
    public override string Name => "Vortex";
}
