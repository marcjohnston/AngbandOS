namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerZSymbol : Symbol
{
    private LowerZSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'z';
    public override string Name => "Zombie/Mummy";
}
