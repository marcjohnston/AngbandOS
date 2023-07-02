namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpStairsSymbol : Symbol
{
    private UpStairsSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '<';
    public override string Name => "An up staircase";
}
