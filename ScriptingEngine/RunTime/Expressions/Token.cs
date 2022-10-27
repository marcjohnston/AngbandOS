using byMarc.Net2.Library.Tokens;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class Token : Expression
    {

        public readonly Expression Text;
        public readonly Expression Delimiter;
        public readonly Expression FieldIndex;
        public readonly Expression ReturnRemainingFields;
        protected override DataValue DoCompute(Job job)
        {
            StringValue textResult = (StringValue)Text.Compute<StringValue>(job, false);
            StringValue delimiterResult = (StringValue)Delimiter.Compute<StringValue>(job, false);
            IntegerValue fieldIndexResult = (IntegerValue)FieldIndex.Compute<IntegerValue>(job, false);
            BooleanValue returnRemainingFieldsResult = (BooleanValue)ReturnRemainingFields.Compute<BooleanValue>(job, false);
            return new StringValue(TokenLib.Token(textResult.Value, delimiterResult.Value, fieldIndexResult.Value, returnRemainingFieldsResult.Value));
        }
        public Token(Expression text, Expression delimiter, Expression fieldIndex) : this(null, text, delimiter, fieldIndex, new FalseExpression(null))
        {
        }
        public Token(Expression text, Expression delimiter, Expression fieldIndex, bool returnRemainingFields) : this(null, text, delimiter, fieldIndex, new FalseExpression(null))
        {
        }
        public Token(DebugSymbol debugSymbol, Expression text, Expression delimiter, Expression fieldIndex) : this(debugSymbol, text, delimiter, fieldIndex, new FalseExpression(null))
        {
        }
        public Token(DebugSymbol debugSymbol, Expression text, Expression delimiter, Expression fieldIndex, Expression returnRemainingFields) : base(debugSymbol)
        {
            Text = text;
            Delimiter = delimiter;
            FieldIndex = fieldIndex;
            ReturnRemainingFields = returnRemainingFields;
        }
    }
}