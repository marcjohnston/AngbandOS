namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerZSymbol : Symbol
{
    private LowerZSymbol(Game game) : base(game) { }
    public override char Character => 'z';
    public override string Name => "Zombie/Mummy";
}
