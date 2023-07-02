namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberFourSymbol : Symbol
{
    private NumberFourSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '4';
    public override string Name => "Entrance to Temple";
}
