namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerNSymbol : Symbol
{
    private LowerNSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'n';
    public override string Name => "Naga";
}
