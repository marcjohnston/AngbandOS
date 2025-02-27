namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PeriodSymbol : SymbolGameConfiguration
{
    public override char Character => '·';

    /// <summary>
    /// Returns the period character because the render character does not fall in the ASCII range of 32 to 126.
    /// </summary>
    public override char? QueryCharacter => '.';
    public override string Name => "Floor";
}

