// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal abstract class WizardCommand : IHelpCommand, IGetKey<string>
{
    protected SaveGame SaveGame { get; }
    protected WizardCommand(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() 
    {
        ExecuteScript = ExecuteScriptName == null ? null : SaveGame.SingletonRepository.Scripts.Get(ExecuteScriptName);
    }

    public abstract char KeyChar { get; }

    public virtual bool IsEnabled => true;

    /// <summary>
    /// Returns the name of a group when rendering the wizard help screen; or null, if the command should not be rendered on the help screen.  Returns null, by default.
    /// </summary>
    public virtual HelpGroup? HelpGroup => null;

    /// <summary>
    /// Returns a description of the command to be rendered on the Wizard Help screen.  Returns empty by default.
    /// </summary>
    public virtual string HelpDescription => "";

    /// <summary>
    /// Returns the name of the script to run; or null, if the command is ignored.  Returns null, by default.  This property is bound to the ExecuteScript property during
    /// the bind phase.
    /// </summary>
    protected virtual string? ExecuteScriptName => null;

    public Script? ExecuteScript { get; private set; }
}
