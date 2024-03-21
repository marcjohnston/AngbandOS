
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperWSymbol : Symbol
{
    private UpperWSymbol(Game game) : base(game) { }
    public override char Character => 'W';
    public override string Name => "Wight/Wraith/etc";
}

