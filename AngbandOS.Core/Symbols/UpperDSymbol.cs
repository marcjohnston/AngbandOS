namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperDSymbol : Symbol
{
    private UpperDSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'D';
    public override string Name => "Ancient Dragon/Wyrm";
}
