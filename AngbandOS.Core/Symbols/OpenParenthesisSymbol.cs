namespace AngbandOS.Core.Symbols;

[Serializable]
internal class OpenParenthesisSymbol : Symbol
{
    private OpenParenthesisSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '(';
    public override string Name => "Soft armour";
}
