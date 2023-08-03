namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerRSymbol : Symbol
{
    private LowerRSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'r';
    public override string Name => "Rodent";
}
