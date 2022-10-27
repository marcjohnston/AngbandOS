using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class InStrExpression : Expression
    {

        public readonly Expression Start;
        public readonly Expression StringBeingSearched;
        public readonly Expression StringSought;
        public override object ToText()
        {
            if (!(Start == null))
            {
                return "InStr(" + Conversions.ToString(Start.ToText()) + ", " + Conversions.ToString(StringBeingSearched.ToText()) + ", " + Conversions.ToString(StringSought.ToText()) + ")";
            }
            else
            {
                return "InStr(" + Conversions.ToString(StringBeingSearched.ToText()) + ", " + Conversions.ToString(StringSought.ToText()) + ")";
            }
        }
        protected override DataValue DoCompute(Job job)
        {
            IntegerValue startResult;
            if (!(Start == null))
            {
                startResult = (IntegerValue)Start.Compute<IntegerValue>(job, true);
            }
            else
            {
                startResult = new IntegerValue(1);
            }
            StringValue stringBeingSearchedResult = (StringValue)StringBeingSearched.Compute<StringValue>(job, false);
            StringValue stringSoughtResult = (StringValue)StringSought.Compute<StringValue>(job, false);
            int pos = Strings.InStr(startResult.Value, stringBeingSearchedResult.Value, stringSoughtResult.Value);
            return new IntegerValue(pos);
        }
        public InStrExpression(Expression stringBeingSearched, Expression stringSought) : this(null, null, stringBeingSearched, stringSought)
        {
        }
        public InStrExpression(Expression start, Expression stringBeingSearched, Expression stringSought) : this(null, start, stringBeingSearched, stringSought)
        {
        }
        public InStrExpression(DebugSymbol debugSymbol, Expression stringBeingSearched, Expression stringSought) : this(debugSymbol, null, stringBeingSearched, stringSought)
        {
        }
        public InStrExpression(DebugSymbol debugSymbol, Expression start, Expression stringBeingSearched, Expression stringSought) : base(debugSymbol)
        {
            Start = start;
            StringBeingSearched = stringBeingSearched;
            StringSought = stringSought;
        }
    }
}