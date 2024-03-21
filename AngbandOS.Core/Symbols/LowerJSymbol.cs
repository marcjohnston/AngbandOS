namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerJSymbol : Symbol
{
    private LowerJSymbol(Game game) : base(game) { }
    public override char Character => 'j';
    public override string Name => "Jelly";
}
