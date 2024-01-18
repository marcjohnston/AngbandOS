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

    public virtual string UniqueKey => GetType().Name;

    public string GetKey => UniqueKey;

    public abstract char Key { get; }

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
    /// 
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns>
    /// Returns true, if the command can/should be repeated; false, if the command succeeded or is futile.
    /// </returns>
    public abstract void Execute();
}
