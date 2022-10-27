using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    public class DimCommandParser : CommandParser
    {

        protected override bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            return parser.TryParseKeyword("DIM");
        }
        protected override RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            string identifier = SyntaxParser.ParseObjectName(parser, scriptEngine, workEnvironment, false);
            SyntaxParser.ParseKeyword(parser, "AS");
            var dataType = SyntaxParser.ParseDataType(parser, scriptEngine, workEnvironment);
            var symbol = new RunTime.ObjectSymbol(identifier);
            symbol.Value = dataType.CreateDataValue();
            workEnvironment.AddSymbol(identifier, symbol);
            return new RunTime.Command[] { new RunTime.Dim(DebugSymbol(parser), identifier, dataType) };
        }
    }
}