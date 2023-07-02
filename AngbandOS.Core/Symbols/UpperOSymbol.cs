
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperOSymbol : Symbol
{
    private UpperOSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'O';
    public override string Name => "Ogre";
}

