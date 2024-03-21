
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class PeriodSymbol : Symbol
{
    private PeriodSymbol(Game game) : base(game) { }
    public override char Character => '·';

    /// <summary>
    /// Returns the period character because the render character does not fall in the ASCII range of 32 to 126.
    /// </summary>
    public override char? QueryCharacter => '.';
    public override string Name => "Floor";
}

