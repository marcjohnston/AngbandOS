namespace AngbandOS.Tokens
{
    public static class TokenExtension
    {
        /// <summary>
        /// Returns a delimited substring.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="delimiter"></param>
        /// <param name="fieldIndex"></param>
        /// <param name="fieldCount"></param>
        /// <returns></returns>
        private static string TokenValue(this string s, string delimiter, int fieldIndex, int? fieldCount = null)
        {

            // Check to see if the field count = 0.
            if (fieldCount.HasValue && fieldCount.Value == 0)
            {
                // By definition, return the empty string.
                return "";
            }
            else
            {
                string[] sTokens;

                // Check to see if we are requesting a field index from then end.
                if (fieldIndex < 0)
                {
                    // Extract all tokens ... no limit.
                    sTokens = s.Split(delimiter);

                    // Compute the desired field index.
                    fieldIndex = sTokens.Length + fieldIndex;

                    // Validate the fieldIndex.
                    if (fieldIndex < 0)
                        throw new Exception("FieldIndex specifies a index (<0) that does not exist.");

                    // Compute the number of fields to return.  Return all of them.
                    int count = fieldCount.HasValue ? fieldCount.Value : sTokens.Length - fieldIndex;

                    // Check to see if a negative number of fields being requested.
                    if (count < 0)
                    {
                        // Compute the number of tokens to return.
                        count = sTokens.Length - fieldIndex + count;

                        if (count <= 0)
                            throw new Exception("FieldCount specifies a value (<0) that does not exist.");
                    }

                    // Validate the number of tokens to return.
                    if (sTokens.Length <= count + fieldIndex)
                        count = sTokens.Length - fieldIndex;

                    // Join the tokens back into a string using the delimiter.
                    return String.Join(delimiter, sTokens, fieldIndex, count);
                }
                else
                {
                    sTokens = s.Split(delimiter, fieldIndex + 1);

                    // Check to see if the requested field index is does not exist.
                    if (fieldIndex >= sTokens.Length)
                    {
                        // Return the empty string.
                        return "";
                    }
                    else
                    {
                        // Save the string that contains the data to be saved.  We will need to resplit it.
                        s = sTokens[fieldIndex];

                        // Check to see if all remaining fields were requested.
                        if (fieldCount == null)
                        {
                            // Split all of the tokens so that we can count them.
                            sTokens = s.Split(delimiter);

                            // Now compute the number of desired fields.
                            fieldCount = sTokens.Length + 1;

                            // Check to see if the number of fields to return is valid.
                            if (fieldCount.Value <= 0)
                                throw new Exception("FieldCount specifies a value (<0) that does not exist.");
                        }
                        else if (fieldCount.Value < 0) // Check to see if a negative value was specified for the number of tokens.
                        {
                            // Split all of the tokens so that we can count them.
                            sTokens = s.Split(delimiter);

                            // Now compute the number of desired fields.
                            fieldCount = sTokens.Length + fieldCount.Value;

                            // Check to see if the number of fields to return is valid.
                            if (fieldCount.Value <= 0)
                                throw new Exception("FieldCount specifies a value (<0) that does not exist.");
                        }
                        else
                        {
                            // Split the tokens, but don't bother with the rest that we don't want, just put all of the left overs in the last element.
                            sTokens = s.Split(delimiter, fieldCount.Value + 1);
                        }

                        // Join the tokens back into a string using the delimiter.
                        int count = fieldCount.Value < sTokens.Length ? fieldCount.Value : sTokens.Length;
                        return String.Join(delimiter, sTokens, 0, count);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a single delimited substring.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="delimiter">The delimiters used in the string.</param>
        /// <param name="fieldIndex">
        /// The index of the field to return.  The first token has an index = 0. A value
        /// less than zero will return a token from the end going backwords, with the last token
        /// being -1.  Example: Tokens.Token("a/b/c", "/", -1) returns c.
        /// </param>
        /// <param name="returnRemainingFields">
        /// Specify TRUE to return all remaining fields; specify FALSE, to return 1 field.
        /// </param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Token(this string s, string delimiter, int fieldIndex, bool returnRemainingFields = false)
        {
            if (returnRemainingFields)
            {
                return s.TokenValue(delimiter, fieldIndex, null);
            }
            else
            {
                return s.TokenValue(delimiter, fieldIndex, 1);
            }
        }

        /// <summary>
        /// Returns consecutive delimited substrings.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="delimiter">The delimiters used in the string.</param>
        /// <param name="fieldIndex">
        /// The index of the field to return.  The first token has an index = 0. A value
        /// less than zero will return a token from the end going backwords, with the last token
        /// being -1.  Example: Tokens.Token("a/b/c", "/", -1) returns c.
        /// </param>
        /// <param name="fieldCount">
        /// The number of delimited substrings to return.  A value of 0 will return a blank
        /// string.  If this parameter value is negative, the parameter value is added to the total
        /// number of tokens that are available and that number of tokens is returned.  
        /// Examples:
        /// Tokens.Token("a/b/c/d/e", "/", 0, -1) = "a/b/c/d"
        /// Tokens.Token("a/b/c/d/e", "/", 1, -2) = "b/c"
        /// </param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Token(this string s, string delimiter, int fieldIndex, int fieldCount)
        {
            return s.TokenValue(delimiter, fieldIndex, fieldCount);
        }

        /// <summary>
        /// Returns the number of tokens using a specific delimiter that exists in a string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int TokenCount(this string s, string delimiter)
        {
            if (s == "")
                return 0;
            else
            {
                string[] tokens = s.Split(delimiter);
                return tokens.Length;
            }
        }
    }
}