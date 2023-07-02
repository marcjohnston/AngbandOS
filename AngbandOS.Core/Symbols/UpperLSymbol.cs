namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperLSymbol : Symbol
{
    private UpperLSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'L';
    public override string Name => "Lich";
}
