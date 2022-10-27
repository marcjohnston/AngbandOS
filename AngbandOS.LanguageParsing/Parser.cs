using System;
using System.Collections.Generic;
using static AngbandOS.Strings.StringLib;

namespace byMarc.Net2.Library.LanguageParsing
{

    public class Parser
    {

        private ParsedToken Token(long index, bool ignoreLineFeeds = true)
        {
            if (index >= Tokens.Length)
            {
                return new EmptyToken("", Text.Length);
            }
            if (index < 0L)
            {
                throw new Exception("There is no current token.  A token has been retrieved yet.");
            }
            return Tokens[(int)index];
        }
        private bool EndOfText(int _characterIndex)
        {
            return _characterIndex > Text.Length;
        }
        private char PeekChar(int _characterIndex)
        {
            return PeekString(_characterIndex, 1)[0];
        }
        private string PeekString(int _characterIndex, int length)
        {
            return Text.Substring(_characterIndex, length);
        }
        private char GetChar(ref int _characterIndex)
        {
            return GetString(ref _characterIndex, 1)[0];
        }
        private string GetString(ref int _characterIndex, int length)
        {
            string GetStringRet = default;
            GetStringRet = PeekString(_characterIndex, length);
            _characterIndex = _characterIndex + length;
            return GetStringRet;
        }
        private string MatchDefinedSymbol(int _characterIndex, List<string> definedSymbols)
        {
            // Look for complete recognized words.
            foreach (string definedSymbol in definedSymbols)
            {
                if ((PeekString(_characterIndex, definedSymbol.Length) ?? "") == (definedSymbol ?? ""))
                {
                    return definedSymbol;
                }
            }
            return null;
        }
        /// <summary>
        /// Gets or sets the current token (0-based) being parsed.  Manipulation of this property can be used to look ahead multiple tokens and restore the current index if needed.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int CurrentTokenIndex { get; set; } = -1;
        /// <summary>
        /// Returns the current word and keeps does not move onto the next word.
        /// </summary>
        /// <returns>The current word in the list or empty if there are no more words.</returns>
        /// <remarks></remarks>
        public ParsedToken CurrentToken()
        {
            return Token(CurrentTokenIndex);
        }
        /// <summary>
        /// Returns the text that was parsed.
        /// </summary>
        /// <remarks></remarks>
        public readonly string Text;
        /// <summary>
        /// Returns the current word in the list, consumes it and moves to the next word.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParsedToken GetNextToken()
        {
            // Updating the CurrentTokenIndex moves the pointer ahead.
            CurrentTokenIndex = CurrentTokenIndex + 1;
            return CurrentToken();
        }
        /// <summary>
        /// Returns the next word in the list without consuming the current word.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParsedToken PeekNextToken()
        {
            return Token(CurrentTokenIndex + 1);
        }
        /// <summary>
        /// Returns all words that were parsed from the text.
        /// </summary>
        /// <remarks></remarks>
        public readonly ParsedToken[] Tokens;

        /// <summary>
        /// Parses the input stream for matching tokens from a text string.  The text string is broken into tokens and the tokens from the input string are matched against those tokens.  If the input string tokens do not match, false is returned; otherwise, true is returned.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool TryParseText(string text)
        {
            var textParser = new Parser(text);

            while (!textParser.PeekNextToken().EndOfText)
            {
                if (!((textParser.GetNextToken().MatchedText.ToUpper() ?? "") == (GetNextToken().MatchedText.ToUpper() ?? "")))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Tries to parse a keyword.  Returns TRUE, if the keyword was found; false, otherwise.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool TryParseKeyword(string word, bool allowLeadingWhiteSpace = true)
        {
            // Get the next token, do not lose the value so that we can still do the comparison.  Getting the token keeps the debug symbol in the correct location.
            var nextToken = PeekNextToken();

            // If a word was specified, then compare the token with the word.
            if ((nextToken.MatchedText.ToUpper() ?? "") != (word.ToUpper() ?? ""))
            {
                return false;
            }
            if (!allowLeadingWhiteSpace)
            {
                if (!string.IsNullOrEmpty(nextToken.LeadingWhiteSpace))
                {
                    return false;
                }
            }
            GetNextToken();
            return true;
        }
        /// <summary>
        /// Tries to parse a GUID.  Returns TRUE, if a GUID was found; false, otherwise.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool TryParseGuid(ref Guid guid)
        {
            int index = CurrentTokenIndex;
            ParsedToken token;
            string guidText = null;
            token = GetNextToken();
            if (token.MatchedText.Length != 8 || !IsHexadecimal(token.MatchedText))
            {
                CurrentTokenIndex = index;
                return false;
            }
            guidText += token.MatchedText;
            if (!TryParseKeyword("-", false))
            {
                CurrentTokenIndex = index;
                return false;
            }
            token = GetNextToken();
            if (token.MatchedText.Length != 4 || !IsHexadecimal(token.MatchedText))
            {
                CurrentTokenIndex = index;
                return false;
            }
            guidText += "-" + token.MatchedText;
            if (!TryParseKeyword("-", false))
            {
                CurrentTokenIndex = index;
                return false;
            }
            token = GetNextToken();
            if (token.MatchedText.Length != 4 || !IsHexadecimal(token.MatchedText))
            {
                CurrentTokenIndex = index;
                return false;
            }
            guidText += "-" + token.MatchedText;
            if (!TryParseKeyword("-", false))
            {
                CurrentTokenIndex = index;
                return false;
            }
            token = GetNextToken();
            if (token.MatchedText.Length != 4 || !IsHexadecimal(token.MatchedText))
            {
                CurrentTokenIndex = index;
                return false;
            }
            guidText += "-" + token.MatchedText;
            if (!TryParseKeyword("-", false))
            {
                CurrentTokenIndex = index;
                return false;
            }
            token = GetNextToken();
            if (token.MatchedText.Length != 12 || !IsHexadecimal(token.MatchedText))
            {
                CurrentTokenIndex = index;
                return false;
            }
            guidText += "-" + token.MatchedText;
            guid = new Guid(guidText);
            return true;
        }
        public string UpdatedText()
        {
            var s = new System.Text.StringBuilder();
            foreach (ParsedToken token in Tokens)
            {
                s.Append(token.LeadingWhiteSpace);
                s.Append(token.get_UpdatedText());
            }
            return s.ToString();
        }
        public bool IsUpdated()
        {
            foreach (ParsedToken Token in Tokens)
            {
                if (Token.IsUpdated)
                {
                    return true;
                }
            }
            return false;
        }
        public Parser(string text) : this(text, new ParseLanguage())
        {
        }
        public Parser(string text, ParseLanguage languageConfig)
        {
            int characterIndex = 1;
            var definedSymbols = new List<string>();
            var _tokenList = new List<ParsedToken>();

            Text = text;
            definedSymbols.AddRange(languageConfig.DefinedSymbols);
            string whiteSpaceCharacters = $" \t{(languageConfig.IgnoreLineFeeds ? Constants.vbLf : "")}";
            do
            {
                // Skip white space.
                string leadingWhiteSpace = "";
                while (!EndOfText(characterIndex) && Strings.InStr(whiteSpaceCharacters, Conversions.ToString(PeekChar(characterIndex))) > 0)
                    // Consume the white space.
                    leadingWhiteSpace += Conversions.ToString(GetChar(ref characterIndex));

                // Check to see if there are no characters left.
                if (EndOfText(characterIndex))
                {
                    break;
                }
                else
                {
                    int startPos = characterIndex;

                    // Look for dual and single character linefeeds.
                    if ((PeekString(characterIndex, 2) ?? "") == Constants.vbLf + Constants.vbCr)
                    {
                        string lfCr = GetString(ref characterIndex, 2);
                        if (!languageConfig.IgnoreLineFeeds)
                        {
                            _tokenList.Add(new LFCRToken(leadingWhiteSpace, lfCr, startPos));
                        }
                    }
                    else if ((PeekString(characterIndex, 2) ?? "") == Constants.vbCr + Constants.vbLf)
                    {
                        string crLf = GetString(ref characterIndex, 2);
                        if (!languageConfig.IgnoreLineFeeds)
                        {
                            _tokenList.Add(new CRLFToken(leadingWhiteSpace, crLf, startPos));
                        }
                    }
                    else if (Conversions.ToString(PeekChar(characterIndex)) == Constants.vbCr)
                    {
                        string cr = Conversions.ToString(GetChar(ref characterIndex));
                        if (!languageConfig.IgnoreLineFeeds)
                        {
                            _tokenList.Add(new CRToken(leadingWhiteSpace, cr, startPos));
                        }
                    }
                    else if (Conversions.ToString(PeekChar(characterIndex)) == Constants.vbLf)
                    {
                        string lf = Conversions.ToString(GetChar(ref characterIndex));
                        if (!languageConfig.IgnoreLineFeeds)
                        {
                            _tokenList.Add(new LFToken(leadingWhiteSpace, lf, startPos));
                        }
                    }
                    else
                    {
                        string definedSymbol = MatchDefinedSymbol(characterIndex, definedSymbols);
                        if (!(definedSymbol == null))
                        {
                            characterIndex = characterIndex + Strings.Len(definedSymbol);
                            _tokenList.Add(new DefinedSymbolToken(leadingWhiteSpace, definedSymbol, startPos));
                        }
                        else
                        {
                            // Get the next character, knowing that it is not white space.  At this point we will build a string "s" to contain the recognized token.
                            string s = Conversions.ToString(GetChar(ref characterIndex));

                            // Check to see if this is the beginning of an identifer.
                            if (languageConfig.IdentifierSymbolSet.FirstCharacterSymbolSet.BooleanArray[Strings.Asc(s)])
                            {
                                // Consume an identifier.
                                while (!EndOfText(characterIndex) & languageConfig.IdentifierSymbolSet.RemainingCharactersSymbolSet.BooleanArray[Strings.Asc(PeekChar(characterIndex))])
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));
                                _tokenList.Add(new IdentifierToken(leadingWhiteSpace, s, startPos));
                            }
                            else if (StringLib.IsDigits(s))
                            {
                                // Consume an unsigned number.
                                while (!EndOfText(characterIndex) & StringLib.IsDigits(PeekChar(characterIndex)))
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));

                                // Check for decimal notation.
                                if (languageConfig.RecognizeDecimalNumbers && Conversions.ToString(PeekChar(characterIndex)) == ".")
                                {
                                    // Consume the decimal point.
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));

                                    // Consume the decimal part.
                                    while (!EndOfText(characterIndex) & StringLib.IsDigits(PeekChar(characterIndex)))
                                        s = s + Conversions.ToString(GetChar(ref characterIndex));
                                    _tokenList.Add(new UnsignedDecimalNumberToken(leadingWhiteSpace, s, startPos));
                                }
                                else
                                {
                                    _tokenList.Add(new UnsignedWholeNumberToken(leadingWhiteSpace, s, startPos));
                                }
                            }
                            else if (languageConfig.RecognizeSignedNumbers && s == "+" && StringLib.IsDigits(PeekChar(characterIndex)))
                            {
                                // Consume a signed number.
                                while (!EndOfText(characterIndex) && StringLib.IsDigits(PeekChar(characterIndex)))
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));

                                // Check for decimal notation.
                                if (languageConfig.RecognizeDecimalNumbers && Conversions.ToString(PeekChar(characterIndex)) == ".")
                                {
                                    // Consume the decimal point.
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));

                                    // Consume the decimal part.
                                    while (!EndOfText(characterIndex) && StringLib.IsDigits(PeekChar(characterIndex)))
                                        s = s + Conversions.ToString(GetChar(ref characterIndex));
                                    _tokenList.Add(new PositiveSignedDecimalNumberToken(leadingWhiteSpace, s, startPos, "+", Strings.Mid(s, 2)));
                                }
                                else
                                {
                                    _tokenList.Add(new PositiveSignedWholeNumberToken(leadingWhiteSpace, s, startPos, "+", Strings.Mid(s, 2)));
                                }
                            }
                            else if (languageConfig.RecognizeSignedNumbers && s == "-" && StringLib.IsDigits(PeekChar(characterIndex)))
                            {
                                // Consume a signed number.
                                while (!EndOfText(characterIndex) && StringLib.IsDigits(PeekChar(characterIndex)))
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));

                                // Check for decimal notation.
                                if (languageConfig.RecognizeDecimalNumbers && Conversions.ToString(PeekChar(characterIndex)) == ".")
                                {
                                    // Consume the decimal point.
                                    s = s + Conversions.ToString(GetChar(ref characterIndex));

                                    // Consume the decimal part.
                                    while (!EndOfText(characterIndex) && StringLib.IsDigits(PeekChar(characterIndex)))
                                        s = s + Conversions.ToString(GetChar(ref characterIndex));
                                    _tokenList.Add(new NegativeSignedDecimalNumberToken(leadingWhiteSpace, s, startPos, "-", Strings.Mid(s, 2)));
                                }
                                else
                                {
                                    _tokenList.Add(new NegativeSignedWholeNumberToken(leadingWhiteSpace, s, startPos, "-", Strings.Mid(s, 2)));
                                }
                            }
                            else if (languageConfig.RecognizeSignedNumbers && languageConfig.RecognizeDecimalNumbers && languageConfig.RecognizeMissingWholeValuesOnDecimals && s == "+" && Conversions.ToString(PeekChar(characterIndex)) == ".")
                            {
                                // Consume the decimal point.
                                s += Conversions.ToString(GetChar(ref characterIndex));

                                // Ensure there are digits after the decimal.
                                if (!EndOfText(characterIndex) && StringLib.IsDigits(PeekChar(characterIndex)))
                                {
                                    // Consume a signed decimal with no whole.
                                    while (!EndOfText(characterIndex) & StringLib.IsDigits(PeekChar(characterIndex)))
                                        s = s + Conversions.ToString(GetChar(ref characterIndex));
                                    _tokenList.Add(new MissingWholePositiveSignedDecimalNumberToken(leadingWhiteSpace, s, startPos, "+", Strings.Mid(s, 2)));
                                }
                                else
                                {
                                    // Put the decimal back.
                                    characterIndex -= 1;
                                    _tokenList.Add(new CharSymbolToken(leadingWhiteSpace, s, startPos));
                                }
                            }
                            else if (languageConfig.RecognizeSignedNumbers && languageConfig.RecognizeDecimalNumbers && languageConfig.RecognizeMissingWholeValuesOnDecimals && s == "-" && Conversions.ToString(PeekChar(characterIndex)) == ".")
                            {
                                // Consume the decimal point.
                                s += Conversions.ToString(GetChar(ref characterIndex));

                                // Ensure there are digits after the decimal.
                                if (!EndOfText(characterIndex) && StringLib.IsDigits(PeekChar(characterIndex)))
                                {
                                    // Consume a signed decimal with no whole.
                                    while (!EndOfText(characterIndex) & StringLib.IsDigits(PeekChar(characterIndex)))
                                        s = s + Conversions.ToString(GetChar(ref characterIndex));
                                    _tokenList.Add(new MissingWholeNegativeSignedDecimalNumberToken(leadingWhiteSpace, s, startPos, "-", Strings.Mid(s, 2)));
                                }
                                else
                                {
                                    // Put the decimal back.
                                    characterIndex -= 1;
                                    _tokenList.Add(new CharSymbolToken(leadingWhiteSpace, s, startPos));
                                }
                            }
                            else if (languageConfig.RecognizeDecimalNumbers && s == ".")
                            {
                                // Ensure there are digits after the decimal point.
                                if (!EndOfText(characterIndex) & StringLib.IsDigits(PeekChar(characterIndex)))
                                {
                                    // Consume a unsigned decimal with no whole.
                                    while (!EndOfText(characterIndex) & StringLib.IsDigits(PeekChar(characterIndex)))
                                        s = s + Conversions.ToString(GetChar(ref characterIndex));
                                    _tokenList.Add(new MissingWholeUnsignedDecimalNumberToken(leadingWhiteSpace, s, startPos));
                                }
                                else
                                {
                                    _tokenList.Add(new CharSymbolToken(leadingWhiteSpace, s, startPos));
                                }
                            }
                            else if (languageConfig.RecognizeSingleQuoteLiterals && s == "'" || languageConfig.RecognizeDoubleQuoteLiterals && s == "\"")
                            {
                                // Remember which literal we are working with.
                                string literalChar = s;
                                bool done = false;
                                do
                                {
                                    // Look for double literal.
                                    if ((PeekString(characterIndex, 2) ?? "") == (literalChar + literalChar ?? ""))
                                    {
                                        s = s + literalChar;

                                        // Consume the double literal.
                                        GetChar(ref characterIndex);
                                        GetChar(ref characterIndex);
                                    }
                                    else if (PeekChar(characterIndex) == literalChar)
                                    {
                                        // This is the closing literal.
                                        done = true;
                                    }
                                    else if (!languageConfig.AllowLiteralToSpanMultipleLines && (object)((PeekString(characterIndex, 2) ?? "") == Constants.vbCrLf || Conversions.ToString(PeekChar(characterIndex)) == Constants.vbCr || Conversions.ToString(PeekChar(characterIndex)) == Constants.vbLf)))
                                    {
                                        throw new ParseException("Missing end literal character (" + literalChar + ")", startPos);
                                        done = true;
                                    }
                                    else
                                    {
                                        // Consume the next character and put it into the string to be returned.
                                        s += GetChar(ref characterIndex);
                                    }
                                }
                                while (!(done | EndOfText(characterIndex)));

                                if (EndOfText(characterIndex))
                                {
                                    throw new ParseException("Missing end literal character (" + literalChar + ")", startPos);
                                }

                                // Consume the closing literal.
                                s += GetChar(ref characterIndex);

                                // Return the literal.
                                _tokenList.Add(new LiteralToken(leadingWhiteSpace, s, startPos, s.Substring(2, s.Length - 2)));
                            }
                            else
                            {
                                _tokenList.Add(new CharSymbolToken(leadingWhiteSpace, s, startPos));
                            }
                        }
                    }
                }
            }
            while (true);
            Tokens = _tokenList.ToArray();
        }
    }
}