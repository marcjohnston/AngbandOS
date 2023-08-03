namespace AngbandOS.Core.Symbols;

[Serializable]
internal class AtSymbol : Symbol
{
    private AtSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '@';
    public override string Name => "You (or the entrance to your home)";
}
