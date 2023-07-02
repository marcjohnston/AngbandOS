
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberSixSymbol : Symbol
{
    private NumberSixSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '6';
    public override string Name => "Entrance to Magic Stores";
}

