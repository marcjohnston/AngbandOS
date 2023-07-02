
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerTSymbol : Symbol
{
    private LowerTSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 't';
    public override string Name => "Townsperson";
}

