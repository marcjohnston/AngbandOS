using System;

namespace byMarc.Net2.Library.LanguageParsing
{
    public class ParseException : Exception
    {
        public readonly int CharacterIndex;
        public ParseException(string message, int characterIndex) : base(message)
        {
            CharacterIndex = characterIndex;
        }
    }
}