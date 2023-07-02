namespace AngbandOS.Core.Symbols;

[Serializable]
internal class TildeSymbol : Symbol
{
    private TildeSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '~';
    public override string Name => "A tool (or miscellaneous item)";
}
