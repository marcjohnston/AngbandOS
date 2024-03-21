
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperOSymbol : Symbol
{
    private UpperOSymbol(Game game) : base(game) { }
    public override char Character => 'O';
    public override string Name => "Ogre";
}

