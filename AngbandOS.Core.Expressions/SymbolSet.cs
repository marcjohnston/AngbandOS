namespace AngbandOS.Core.Expressions;

[Serializable]
public class SymbolSet
{
    public readonly bool[] Symbols;
    public bool Contains(char c)
    {
        return Symbols[(byte)c];
    }

    public SymbolSet(string symbols)
    {
        Symbols = new bool[256];
        foreach (char c in symbols)
        {
            Symbols[(byte)c] = true;
        }
    }
}
