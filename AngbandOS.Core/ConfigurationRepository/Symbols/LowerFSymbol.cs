namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerFSymbol : Symbol
{
    private LowerFSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'f';
    public override string Name => "Feline";
}
