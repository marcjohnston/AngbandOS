using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    #region FactorParser - Represents a class that parses script factors and returns a RunTime expression.  Factors are the most basic types of urnary expressions.
    /// <summary>
#Region "FactorParser - Represents a class that parses script factors and returns a RunTime expression.  Factors are the most basic types of urnary expressions."/// Represents a class that parses script factors and returns a RunTime expression.  Factors are the most basic types of urnary expressions.
#Region "FactorParser - Represents a class that parses script factors and returns a RunTime expression.  Factors are the most basic types of urnary expressions."/// </summary>
#Region "FactorParser - Represents a class that parses script factors and returns a RunTime expression.  Factors are the most basic types of urnary expressions."/// <remarks></remarks>
    public abstract class FactorParser
    {
        public abstract RunTime.Expression TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment);
    }
}
#endregion
