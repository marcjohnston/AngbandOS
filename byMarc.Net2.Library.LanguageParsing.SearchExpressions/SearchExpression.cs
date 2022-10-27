using System;
using Microsoft.VisualBasic;

namespace byMarc.Net2.Library.LanguageParsing.SearchExpressions
{

    public abstract class SearchExpression
    {
        public virtual string[] ToKeywords(bool preserveCase = false)
        {
            return new string[] { }; // We cannot return nothing.  It is not valid.
        }
        public bool IsAndSearchExpression()
        {
            return typeof(AndSearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsOrSearchExpression()
        {
            return typeof(OrSearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsBinarySearchExpression()
        {
            return typeof(BinarySearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsUnarySearchExpression()
        {
            return typeof(UnarySearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsNotSearchExpression()
        {
            return typeof(NotSearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsParenthesisSearchExpression()
        {
            return typeof(ParenthesisSearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsKeywordSearchExpression()
        {
            return typeof(KeywordSearchExpression).IsAssignableFrom(GetType());
        }
        public bool IsSymbolKeywordSearchExpression()
        {
            return IsKeywordSearchExpression() && Strings.Len(((KeywordSearchExpression)this).Term) <= 1;
        }
        public SearchExpression Reduce()
        {
            switch (true)
            {
                case object _ when IsBinarySearchExpression():
                    {
                        {
                            var withBlock = (BinarySearchExpression)this;
                            // Recursively process the two terms.
                            var term1 = withBlock.Term1.DropSymbolsFromExpression();
                            var term2 = withBlock.Term2.DropSymbolsFromExpression();

                            // Now process just this AND statement.
                            if (term1 == null || term1.IsSymbolKeywordSearchExpression())
                            {
                                // Term1 is gone or was just a symbol, check term2.
                                if (term2 == null || term2.IsSymbolKeywordSearchExpression())
                                {
                                    // Both terms are gone or were just symbols.  Drop both sides.
                                    return null;
                                }
                                else
                                {
                                    // Term1 is gone or was just a symbol, but term2 is not.  Drop just the term1 side and return just term2.
                                    return term2;
                                }
                            }
                            // Term1 is not a symbol, check term2.
                            else if (term2 == null || term2.IsSymbolKeywordSearchExpression())
                            {
                                // Term1 is not a symbol, but term2 is now gone or was just a symbol.  Drop term2 and return term1.
                                return term1;
                            }
                            else
                            {
                                // Neither term1 nor term2 are symbols or gone, reconstruct the search expression.
                                switch (true)
                                {
                                    case object _ when IsAndSearchExpression():
                                        {
                                            return new AndSearchExpression(term1, term2);
                                        }
                                    case object _ when IsOrSearchExpression():
                                        {
                                            return new OrSearchExpression(term1, term2);
                                        }

                                    default:
                                        {
                                            throw new Exception("Unknown expression type.");
                                        }
                                }
                            }
                        }

                        break;
                    }
                case object _ when IsUnarySearchExpression():
                    {
                        {
                            var withBlock1 = (UnarySearchExpression)this;
                            var term = withBlock1.Term.DropSymbolsFromExpression();
                            if (term == null || term.IsSymbolKeywordSearchExpression())
                            {
                                return null;
                            }
                            else
                            {
                                switch (true)
                                {
                                    case object _ when IsNotSearchExpression():
                                        {
                                            return new NotSearchExpression(term);
                                        }
                                    case object _ when IsParenthesisSearchExpression():
                                        {
                                            return new ParenthesisSearchExpression(term);
                                        }

                                    default:
                                        {
                                            throw new Exception("Unknown expression type.");
                                        }
                                }
                            }
                        }

                        break;
                    }
                case object _ when IsParenthesisSearchExpression():
                    {
                        // Drop the parenthesis.  The structure of the tree performs the same function.
                        return ((ParenthesisSearchExpression)this).Term;
                    }

                default:
                    {
                        return this;
                    }
            }
        }
        public SearchExpression DropSymbolsFromExpression()
        {
            switch (true)
            {
                case object _ when IsBinarySearchExpression():
                    {
                        {
                            var withBlock = (BinarySearchExpression)this;
                            // Recursively process the two terms.
                            var term1 = withBlock.Term1.DropSymbolsFromExpression();
                            var term2 = withBlock.Term2.DropSymbolsFromExpression();

                            // Now process just this AND statement.
                            if (term1 == null || term1.IsSymbolKeywordSearchExpression())
                            {
                                // Term1 is gone or was just a symbol, check term2.
                                if (term2 == null || term2.IsSymbolKeywordSearchExpression())
                                {
                                    // Both terms are gone or were just symbols.  Drop both sides.
                                    return null;
                                }
                                else
                                {
                                    // Term1 is gone or was just a symbol, but term2 is not.  Drop just the term1 side and return just term2.
                                    return term2;
                                }
                            }
                            // Term1 is not a symbol, check term2.
                            else if (term2 == null || term2.IsSymbolKeywordSearchExpression())
                            {
                                // Term1 is not a symbol, but term2 is now gone or was just a symbol.  Drop term2 and return term1.
                                return term1;
                            }
                            else
                            {
                                // Neither term1 nor term2 are symbols or gone, reconstruct the search expression.
                                switch (true)
                                {
                                    case object _ when IsAndSearchExpression():
                                        {
                                            return new AndSearchExpression(term1, term2);
                                        }
                                    case object _ when IsOrSearchExpression():
                                        {
                                            return new OrSearchExpression(term1, term2);
                                        }

                                    default:
                                        {
                                            throw new Exception("Unknown expression type.");
                                        }
                                }
                            }
                        }

                        break;
                    }
                case object _ when IsUnarySearchExpression():
                    {
                        {
                            var withBlock1 = (UnarySearchExpression)this;
                            var term = withBlock1.Term.DropSymbolsFromExpression();
                            if (term == null || term.IsSymbolKeywordSearchExpression())
                            {
                                return null;
                            }
                            else
                            {
                                switch (true)
                                {
                                    case object _ when IsNotSearchExpression():
                                        {
                                            return new NotSearchExpression(term);
                                        }
                                    case object _ when IsParenthesisSearchExpression():
                                        {
                                            return new ParenthesisSearchExpression(term);
                                        }

                                    default:
                                        {
                                            throw new Exception("Unknown expression type.");
                                        }
                                }
                            }
                        }

                        break;
                    }
                case object _ when IsSymbolKeywordSearchExpression():
                    {
                        return null;
                    }

                default:
                    {
                        return this;
                    }
            }
        }
    }
}