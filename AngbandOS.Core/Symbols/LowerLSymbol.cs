
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerLSymbol : Symbol
{
    private LowerLSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'l';
    public override string Name => "Louse";
}

