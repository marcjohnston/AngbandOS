namespace AngbandOS.Core.Symbols;

[Serializable]
internal class CloseBraceSymbol : Symbol
{
    private CloseBraceSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ']';
    public override string Name => "Misc. armour";
}
