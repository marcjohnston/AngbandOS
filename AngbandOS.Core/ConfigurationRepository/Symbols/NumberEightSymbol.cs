namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberEightSymbol : Symbol
{
    private NumberEightSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '8';
    public override string Name => "Entrance to Hall of Records";
}
