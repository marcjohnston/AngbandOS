
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class PeriodSymbol : Symbol
{
    private PeriodSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '.';
    public override char QueryCharacter => '·';
    public override string Name => "Floor";
}

