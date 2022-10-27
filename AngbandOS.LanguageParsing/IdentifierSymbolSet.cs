namespace byMarc.Net2.Library.LanguageParsing
{
    public class IdentifierSymbolSet
    {
        public SymbolSet FirstCharacterSymbolSet;
        public SymbolSet RemainingCharactersSymbolSet;
        public IdentifierSymbolSet(SymbolSet firstCharacterSymbolSet, SymbolSet remainingCharactersSymbolSet)
        {
            FirstCharacterSymbolSet = firstCharacterSymbolSet;
            RemainingCharactersSymbolSet = remainingCharactersSymbolSet;
        }
    }
}