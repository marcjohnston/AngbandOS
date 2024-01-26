
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberTwoSymbol : Symbol
{
    private NumberTwoSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '2';
    public override string Name => "Entrance to Armory";
}

