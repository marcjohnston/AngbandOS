namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperUSymbol : Symbol
{
    private UpperUSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'U';
    public override string Name => "Major Demon";
}
