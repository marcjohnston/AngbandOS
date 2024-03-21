namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperQSymbol : Symbol
{
    private UpperQSymbol(Game game) : base(game) { }
    public override char Character => 'Q';
    public override string Name => "Quylthulg (Pulsing Flesh Mound)";
}
