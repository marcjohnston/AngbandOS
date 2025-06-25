// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class WizardCommand : IHelpCommand, IGetKey, IToJson
{
    protected readonly Game Game;
    public WizardCommand(Game game, WizardCommandGameConfiguration wizardCommandGameConfiguration)
    {
        Game = game;
        Key = wizardCommandGameConfiguration.Key ?? wizardCommandGameConfiguration.GetType().Name;
        KeyChar = wizardCommandGameConfiguration.KeyChar;
        IsEnabled = wizardCommandGameConfiguration.IsEnabled;
        ExecuteScriptName = wizardCommandGameConfiguration.ExecuteScriptName;
        HelpDescription = wizardCommandGameConfiguration.HelpDescription;
        HelpGroupName = wizardCommandGameConfiguration.HelpGroupName;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        WizardCommandGameConfiguration definition = new WizardCommandGameConfiguration()
        {
            Key = Key,
            ExecuteScriptName = ExecuteScriptName,
            HelpDescription = HelpDescription,
            HelpGroupName = HelpGroupName,
            IsEnabled = IsEnabled,
            KeyChar = KeyChar
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind() 
    {
        ExecuteScript = ExecuteScriptName == null ? null : Game.SingletonRepository.Get<IScript>(ExecuteScriptName);
        HelpGroup = HelpGroupName == null ? null : Game.SingletonRepository.Get<HelpGroup>(HelpGroupName);
    }

    public virtual char KeyChar { get; }

    public virtual bool IsEnabled { get; } = true;

    /// <summary>
    /// Returns the name of a group when rendering the wizard help screen; or null, if the command should not be rendered on the help screen.  Returns null, by default.
    /// </summary>
    public HelpGroup? HelpGroup { get; private set; }

    protected virtual string? HelpGroupName { get; } = null;

    /// <summary>
    /// Returns a description of the command to be rendered on the Wizard Help screen.  Returns empty by default.
    /// </summary>
    public virtual string HelpDescription { get; } = "";

    /// <summary>
    /// Returns the name of the script to run; or null, if the command is ignored.  Returns null, by default.  This property is bound to the ExecuteScript property during
    /// the bind phase.
    /// </summary>
    protected virtual string? ExecuteScriptName { get; } = null;

    public IScript? ExecuteScript { get; private set; }
}
