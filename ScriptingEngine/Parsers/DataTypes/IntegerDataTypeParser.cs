using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class IntegerDataTypeParser : DataTypeParser
    {

        protected override DataType Parse(Parser parser, RunTime.WorkEnvironment workEnvironment)
        {
            return new IntegerDataType(DebugSymbol(parser));
        }
        protected override bool Peek(Parser parser, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("INTEGER");
        }
    }
}