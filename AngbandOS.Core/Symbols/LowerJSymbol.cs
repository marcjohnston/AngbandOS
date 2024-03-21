namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerJSymbol : Symbol
{
    private LowerJSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'j';
    public override string Name => "Jelly";
}
