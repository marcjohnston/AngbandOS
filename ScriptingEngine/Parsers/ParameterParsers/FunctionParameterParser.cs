using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    #region ParameterDeclaration - Represents a class that parses parameters for functions.  Optionality is supported.
    /// <summary>
#Region "ParameterDeclaration - Represents a class that parses parameters for functions.  Optionality is supported."/// Represents a class that parses parameters for functions.  Optionality is supported.
#Region "ParameterDeclaration - Represents a class that parses parameters for functions.  Optionality is supported."/// </summary>
#Region "ParameterDeclaration - Represents a class that parses parameters for functions.  Optionality is supported."/// <remarks></remarks>
    public abstract class FunctionParameterParser
    {
        public abstract RunTime.ParameterSymbol TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment);
        public readonly bool IsOptional;
        public FunctionParameterParser(bool isOptional = false)
        {
            IsOptional = isOptional;
        }
    }
}
#endregion
