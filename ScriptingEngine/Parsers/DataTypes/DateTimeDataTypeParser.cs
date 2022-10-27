using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class DateTimeDataTypeParser : DataTypeParser
    {

        protected override DataType Parse(Parser parser, RunTime.WorkEnvironment workEnvironment)
        {
            return new DateTimeDataType(DebugSymbol(parser));
        }
        protected override bool Peek(Parser parser, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("DATETIME");
        }
    }
}