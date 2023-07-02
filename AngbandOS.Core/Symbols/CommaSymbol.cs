namespace AngbandOS.Core.Symbols;

[Serializable]
internal class CommaSymbol : Symbol
{
    private CommaSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ',';
    public override string Name => "Food (or mushroom patch)";
}
