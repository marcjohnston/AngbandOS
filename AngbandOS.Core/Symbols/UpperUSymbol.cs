namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperUSymbol : Symbol
{
    private UpperUSymbol(Game game) : base(game) { }
    public override char Character => 'U';
    public override string Name => "Major Demon";
}
