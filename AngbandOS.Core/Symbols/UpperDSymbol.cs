namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperDSymbol : Symbol
{
    private UpperDSymbol(Game game) : base(game) { }
    public override char Character => 'D';
    public override string Name => "Ancient Dragon/Wyrm";
}
