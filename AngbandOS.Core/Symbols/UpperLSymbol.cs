namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperLSymbol : Symbol
{
    private UpperLSymbol(Game game) : base(game) { }
    public override char Character => 'L';
    public override string Name => "Lich";
}
