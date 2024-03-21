
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperWSymbol : Symbol
{
    private UpperWSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'W';
    public override string Name => "Wight/Wraith/etc";
}

