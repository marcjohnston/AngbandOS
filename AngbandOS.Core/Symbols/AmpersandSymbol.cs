
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class AmpersandSymbol : Symbol
{
    private AmpersandSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '&';
    public override string Name => "Entrance to Inn";
}

