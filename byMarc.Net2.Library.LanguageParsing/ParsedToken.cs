using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace byMarc.Net2.Library.LanguageParsing
{
    public class ParsedToken
    {

        private string _updatedText;

        public int EndCharacterIndex
        {
            get
            {
                return StartCharacterIndex + MatchedLength;
            }
        }
        public int MatchedLength
        {
            get
            {
                return MatchedText.Length;
            }
        }

        /// <summary>
        /// Returns true, if the token is a non-alphanumeric character; false, otherwise.  Tokens will only be 1 character in length and will not be alphanumeric or whitespace.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsCharSymbol
        {
            get
            {
                return typeof(CharSymbolToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsDecimalNumber
        {
            get
            {
                return typeof(DecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a predefined symbol; false, otherwise.  Tokens will be a defined word.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsDefinedSymbol
        {
            get
            {
                return typeof(DefinedSymbolToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if there were no more tokens found in the stream; false, otherwise.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool EndOfText
        {
            get
            {
                return typeof(EmptyToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token starts with an alphabetic character and is alphanumeric thereafter; false, otherwise. Tokens will start with an alphabetic character and every other character will be alphanumeric.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsIdentifier
        {
            get
            {
                return typeof(IdentifierToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a linefeed; false, otherwise.  Tokens will match one of: CR, LF, CRLF, LFCR.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsLineFeed
        {
            get
            {
                return typeof(LineFeedToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, when the text was parsed with IgnoreLineFeeds enabled and the token is the first token on a new line; otherwise, false is returned.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsOnNewLine
        {
            get
            {
                return Strings.InStr(LeadingWhiteSpace, Constants.vbCr) > 0 || Strings.InStr(LeadingWhiteSpace, Constants.vbLf) > 0;
            }
        }

        /// <summary>
        /// Returns true, if the token is a literal string; false, otherwise.  Tokens will start with a literal character and end with the matching literal character.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsLiteral
        {
            get
            {
                return typeof(LiteralToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is missing the whole number and is a decimal number; false, otherwise,  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsMissingWholeDecimalNumber
        {
            get
            {
                return IsMissingWholeSignedDecimalNumber || IsMissingWholeUnsignedDecimalNumber;
            }
        }

        /// <summary>
        /// Returns true, if the token is missing the whole number and is a negatively signed decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsMissingWholeNegativeSignedDecimalNumber
        {
            get
            {
                return typeof(MissingWholeNegativeSignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is missing the whole number and is a positively signed decimal number; false; otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsMissingWholePositiveSignedDecimalNumber
        {
            get
            {
                return typeof(MissingWholePositiveSignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is missing the whole number and is a signed decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsMissingWholeSignedDecimalNumber
        {
            get
            {
                return IsMissingWholePositiveSignedDecimalNumber || IsMissingWholeNegativeSignedDecimalNumber;
            }
        }

        /// <summary>
        /// Returns true, if the token is missing the whole number and is an unsigned decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsMissingWholeUnsignedDecimalNumber
        {
            get
            {
                return typeof(MissingWholeUnsignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a negatively signed decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsNegativeSignedDecimalNumber
        {
            get
            {
                return typeof(NegativeSignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a signed whole or decimal number; false, otherwise.  Tokens will be numeric in nature.  The first character will be either a plus or negative character.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsNegativeSignedNumber
        {
            get
            {
                return IsNegativeSignedWholeNumber || IsNegativeSignedDecimalNumber;
            }
        }

        /// <summary>
        /// Returns true, if the token is a negatively signed whole number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsNegativeSignedWholeNumber
        {
            get
            {
                return typeof(NegativeSignedWholeNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a whole or decimal, signed or unsigned number; false, otherwise.  Tokens will be numeric in nature.  They can be either whole or decimal, signed or unsigned and may include or be missing the whole number.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsNumber
        {
            get
            {
                return typeof(NumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a positively signed decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsPositiveSignedDecimalNumber
        {
            get
            {
                return typeof(PositiveSignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a signed whole or decimal number; false, otherwise.  Tokens will be numeric in nature.  The first character will be either a plus or negative character.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsPositiveSignedNumber
        {
            get
            {
                return IsPositiveSignedWholeNumber || IsPositiveSignedDecimalNumber;
            }
        }

        /// <summary>
        /// Returns true, if the token is a positively signed whole number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsPositiveSignedWholeNumber
        {
            get
            {
                return typeof(PositiveSignedWholeNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a signed decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsSignedDecimalNumber
        {
            get
            {
                return typeof(SignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a signed whole or decimal number; false, otherwise.  Tokens will be numeric in nature.  The first character will be either a plus or negative character.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsSignedNumber
        {
            get
            {
                return IsSignedWholeNumber || IsSignedDecimalNumber;
            }
        }

        /// <summary>
        /// Returns true, if the token is a signed whole number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsSignedWholeNumber
        {
            get
            {
                return typeof(SignedWholeNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is either a predefined symbol or a single non-alphanumeric character; false, otherwise.  Tokens will either be a single character or a defined word.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsSymbol
        {
            get
            {
                return typeof(SymbolToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Return true, if the token is an unsigned decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsUnsignedDecimalNumber
        {
            get
            {
                return typeof(UnsignedDecimalNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is an unsigned whole or decimal number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsUnsignedNumber
        {
            get
            {
                return IsUnsignedWholeNumber || IsUnsignedDecimalNumber;
            }
        }

        /// <summary>
        /// Returns true, if the token is an unsigned whole number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsUnsignedWholeNumber
        {
            get
            {
                return typeof(UnsignedWholeNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns true, if the token is a signed or unsigned whole number; false, otherwise.  Tokens will be numeric in nature.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool IsWholeNumber
        {
            get
            {
                return typeof(WholeNumberToken).IsAssignableFrom(GetType());
            }
        }

        /// <summary>
        /// Returns the white space text that was found preceeding the token.  Any whitespace after the last ParsedToken is not retrievable.
        /// </summary>
        /// <remarks></remarks>
        public readonly string LeadingWhiteSpace;

        /// <summary>
        /// Returns the text that was matched in the source text.
        /// </summary>
        /// <remarks></remarks>
        public readonly string MatchedText;

        /// <summary>
        /// Returns the 1-based index of the first character of the matched text for the token in the source text.
        /// </summary>
        /// <remarks></remarks>
        public readonly int StartCharacterIndex;

        public string get_UpdatedText(bool includeLeadingWhiteSpace = true)
        {
            return Conversions.ToString(Operators.AddObject(Interaction.IIf(includeLeadingWhiteSpace, LeadingWhiteSpace, ""), _updatedText));
        }

        public void set_UpdatedText(bool includeLeadingWhiteSpace = true, string value = default)
        {
            _updatedText = value;
        }
        public bool IsUpdated
        {
            get
            {
                return (get_UpdatedText() ?? "") != (MatchedText ?? "");
            }
        }

        /// <summary>
        /// Creates a new parsed token.
        /// </summary>
        /// <param name="matchedText"></param>
        /// <param name="characterIndex"></param>
        /// <remarks></remarks>
        public ParsedToken(string leadingWhiteSpace, string matchedText, int characterIndex)
        {
            LeadingWhiteSpace = leadingWhiteSpace;
            MatchedText = matchedText;
            set_UpdatedText(value: matchedText);
            StartCharacterIndex = characterIndex;
        }
    }
}