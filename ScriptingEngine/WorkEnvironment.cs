using System.Collections.Generic;
using byMarc.Net2.Library.Collections.CaseInsensitiveDictionary;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    #region WorkEnvironment - Represents a class that stores runtime data.  Runtime data is used during compilation and execution.
    /// <summary>
    /// Represents a class that stores runtime data.  Runtime data is used during compilation and execution.
    /// </summary>
    /// <remarks>
    /// Add-in modules that require additional runtime data can use the GetSetting and SetSetting functions.
    /// </remarks>
    public partial class WorkEnvironment
    {

        #region Private, Protected & Friends
        protected void RaiseSettingChanged(string settingName)
        {
            SettingChanged?.Invoke(settingName);
        }
        #region Objects - Returns a case-insensitive dictionary of all objects currently in the runtime environment.
        /// <summary>
        /// Returns a case-insensitive dictionary of all objects currently in the runtime environment.
        /// </summary>
        /// <remarks></remarks>
        private readonly List<CaseInsensitiveDictionary<Symbol>> _symbols = new List<CaseInsensitiveDictionary<Symbol>>();
        private CaseInsensitiveDictionary<Symbol> Symbols
        {
            get
            {
                return _symbols[0];
            }
        }
        #endregion
        #endregion

        #region Public Events
        #region SettingChanged - Fired when a setting is added or modified.
        /// <summary>
        /// Fired when a setting is added or modified.
        /// </summary>
        /// <param name="settingName"></param>
        /// <remarks></remarks>
        public event SettingChangedEventHandler SettingChanged;

        public delegate void SettingChangedEventHandler(string settingName);
        #endregion
        #endregion

        #region Public Properties
        #region CurrentProgress - Returns the current runtime progress for the script.  The runtime progress is controlled via specific script commands and allows a script to identify a current status to the external application and/or IDE.  Use the SetProgress, SetProgressMax and SetProgressStage script commands.
        /// <summary>
        /// Returns the current runtime progress for the script.  The runtime progress is controlled via specific script commands and allows a script to identify a current status to the external application and/or IDE.  Use the SetProgress, SetProgressMax and SetProgressStage script commands.
        /// </summary>
        /// <remarks></remarks>
        public readonly Progress CurrentProgress;
        #endregion
        public bool ObjectExists(string name)
        {
            return !(TryGetSymbol(name) == null);
        }
        /// <summary>
        /// Retrieves a symbol from the symbol table.  Nothing is returned, if the symbol is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Symbol TryGetSymbol(string name)
        {
            Symbol symbol = null;
            int currentScope = 0;
            while (currentScope < _symbols.Count && !_symbols[currentScope].TryGetValue(name, ref symbol))
                currentScope += 1;
            return symbol;
        }
        /// <summary>
        /// Retrieves a symbol from the symbol table.  Throws a run-time exception if the symbol is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Symbol GetSymbol(string name)
        {
            var symbol = TryGetSymbol(name);
            if (symbol == null)
            {
                throw new RunTimeErrorScriptException("Variable " + name + " not defined.");
            }
            else
            {
                return symbol;
            }
        }
        /// <summary>
        /// Adds a symbol to the symbols table.  The name must be unique.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <remarks></remarks>
        public void AddSymbol(string name, Symbol value)
        {
            Symbols.Add(name, value);
        }
        #region Settings - Gets or sets a specific setting by name.
        /// <summary>
        /// Gets or sets a specific setting by name.
        /// </summary>
        /// <remarks></remarks>
        public readonly CaseInsensitiveDictionary<object> Settings = new CaseInsensitiveDictionary<object>();
        #endregion
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a new scope for symbols to be added to the symbol table.  All symbols added to the symbol table will be added to the current scope.
        /// </summary>
        /// <remarks></remarks>
        public void PushScope()
        {
            _symbols.Insert(0, new CaseInsensitiveDictionary<Symbol>());
        }
        /// <summary>
        /// Pops the current scope from the symbol table, deleting all of the symbols that belonged to it.
        /// </summary>
        /// <remarks></remarks>
        public void PopScope()
        {
            _symbols.RemoveAt(0);
        }
        /// <summary>
        /// Deletes all of the scopes and symbols from the symbol table.
        /// </summary>
        /// <remarks></remarks>
        public void Clear()
        {
            Settings.Clear();
            _symbols.Clear();
            PushScope();
        }
        #region GetSetting - Returns a strongly-typed setting by name.
        /// <summary>
        /// Returns a strongly-typed setting by name.  If the setting doesn't exist, nothing is returned.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="settingName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public t GetSetting<t>(string settingName)
        {
            return GetSetting(settingName, default(t));
        }
        /// <summary>
        /// Returns a strongly-typed setting by name.  If the setting doesn't exist, the setting is created using the specified default value and the default value is returned.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="settingName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public t GetSetting<t>(string settingName, t defaultValue)
        {
            object value = null;
            if (Settings.TryGetValue(settingName, ref value))
            {
                return Conversions.ToGenericParameter<t>(value);
            }
            else
            {
                SetSetting(settingName, defaultValue);
                return defaultValue;
            }
        }
        #endregion
        #region SetSetting - Creates or modifies a setting.  If the setting doesn't exist, it is automatically created.  The SettingChanged event is fired automatically afterwards.
        /// <summary>
        /// Creates or modifies a setting.  If the setting doesn't exist, it is automatically created.  The SettingChanged event is fired automatically afterwards.
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="value"></param>
        /// <remarks></remarks>
        public void SetSetting(string settingName, object value)
        {
            if (Settings.ContainsKey(settingName))
            {
                Settings[settingName] = value;
            }
            else
            {
                Settings.Add(settingName, value);
            }
            RaiseSettingChanged(settingName);
        }
        #endregion
        #endregion

        public WorkEnvironment()
        {
            CurrentProgress = new Progress(this);
            Clear();
        }
    }
    #endregion

}