
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberSixSymbol : Symbol
{
    private NumberSixSymbol(Game game) : base(game) { }
    public override char Character => '6';
    public override string Name => "Entrance to Magic Stores";
}

