using System;
using System.Collections.Generic;
using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    /// <summary>
    /// Represents an extensible scripting engine that can compile and execute scripts.
    /// </summary>
    /// <remarks></remarks>
    public class ScriptEngine
    {

        /// <summary>
        /// Fired when an AddIn is installed.
        /// </summary>
        /// <param name="addIn"></param>
        /// <remarks></remarks>
        public event AddInInstalledEventHandler AddInInstalled;

        public delegate void AddInInstalledEventHandler(AddIn addIn);

        public readonly List<AddIn> InstalledAddIns = new List<AddIn>();
        public readonly List<CommandParser> InstalledCommandParsers = new List<CommandParser>();
        public readonly List<DataTypeParser> InstalledDataTypeParsers = new List<DataTypeParser>();
        public readonly List<FactorParser> InstalledFactorParsers = new List<FactorParser>();
        public AddIn get_InstalledAddIn(Guid guid)
        {
            foreach (AddIn installedAddInItem in InstalledAddIns)
            {
                if (installedAddInItem.Guid.Equals(guid))
                {
                    return installedAddInItem;
                }
            }
            return null;
        }

        /// <summary>
        /// Compiles a script synchronously and returns a runtime job.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public RunTime.Job Compile(string script, object data)
        {
            // The compiler needs a temporary runtime environment.
            var workEnvironment = new RunTime.WorkEnvironment();
            Parser parser;
            try
            {
                // Create a new parser.  If a parse exception is thrown, we need to catch it.
                parser = new Parser(script);
            }
            catch (ParseException ex)
            {
                throw new SyntaxErrorScriptException("Parser error.  " + ex.Message, ex.CharacterIndex, "");
            }
            var commands = SyntaxParser.TryParseCommands(parser, this, workEnvironment);
            if (!parser.PeekNextToken().EndOfText)
            {
                throw new SyntaxErrorScriptException("Unknown object or command.", parser.GetNextToken());
            }
            return new RunTime.Job(this, script, commands, data);
        }
        public AddInManager AddInManagerWindow
        {
            get
            {
                return new AddInManager(this);
            }
        }
        public void InstallAddInModule(AddIn addIn)
        {
            // Ensure the AddIn doesn't have a duplicate Guid.
            if (!(get_InstalledAddIn(addIn.Guid) == null))
            {
                throw new Exception("A duplicate Guid error was encountered.");
            }

            // Add the module to the list of installed add-in modules.
            InstalledAddIns.Add(addIn);

            // Add all of the factor parsers.
            if (!(addIn.FactorParsers == null))
            {
                foreach (FactorParser factorParser in addIn.FactorParsers)
                    InstalledFactorParsers.Add(factorParser);
            }

            // Add all of the factor parsers.
            if (!(addIn.CommandParsers == null))
            {
                foreach (CommandParser commandParser in addIn.CommandParsers)
                    InstalledCommandParsers.Add(commandParser);
            }

            // Add all of the data type parsers.
            if (!(addIn.DataTypeParsers == null))
            {
                foreach (DataTypeParser dataTypeParser in addIn.DataTypeParsers)
                    InstalledDataTypeParsers.Add(dataTypeParser);
            }

            AddInInstalled?.Invoke(addIn);
        }
        public void InstallAddInModules(System.Reflection.Assembly assembly)
        {
            // Enumerate all of the types contained in the assembly.
            var types = assembly.GetTypes();

            // Loop through each of the types.
            foreach (Type type in types)
            {
                // Check to see if the type is inherited from the AddIn class.  Ensure that the type isn't the AddIn class itself.
                if (typeof(AddIn).IsAssignableFrom(type) && !ReferenceEquals(type, typeof(AddIn)))
                {
                    // Instantiate the add-in module.
                    AddIn addIn = (AddIn)Activator.CreateInstance(type);

                    // Install the add-in module.
                    InstallAddInModule(addIn);
                }
            }
        }
        public void Unload()
        {
            foreach (AddIn addIn in InstalledAddIns)
                addIn.Unload();
        }
    }
}

