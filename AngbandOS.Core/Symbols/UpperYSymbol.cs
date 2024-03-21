namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperYSymbol : Symbol
{
    private UpperYSymbol(Game game) : base(game) { }
    public override char Character => 'Y';
    public override string Name => "Yeti";
}
