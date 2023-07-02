namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperQSymbol : Symbol
{
    private UpperQSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'Q';
    public override string Name => "Quylthulg (Pulsing Flesh Mound)";
}
