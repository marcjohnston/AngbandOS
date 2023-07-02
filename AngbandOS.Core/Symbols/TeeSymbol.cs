
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class TeeSymbol : Symbol
{
    private TeeSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '|';
    public override string Name => "An edged weapon (sword/dagger/etc)";
}

