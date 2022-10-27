using Microsoft.VisualBasic;

namespace byMarc.Net2.Library.LanguageParsing
{
    public class SymbolSet
    {
        public readonly bool[] BooleanArray;
        public SymbolSet(string symbolSet)
        {
            BooleanArray = new bool[256];
            foreach (char c in symbolSet)
                BooleanArray[Strings.Asc(c)] = true;
        }
    }
}