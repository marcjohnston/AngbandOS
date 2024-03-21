namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperYSymbol : Symbol
{
    private UpperYSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'Y';
    public override string Name => "Yeti";
}
