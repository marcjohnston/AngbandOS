
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperFSymbol : Symbol
{
    private UpperFSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'F';
    public override string Name => "Dragon Fly";
}

