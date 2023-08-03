// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

[Serializable]
internal abstract class GameCommand : IConfigurationRepository
{
    protected SaveGame SaveGame { get; }
    protected GameCommand(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract char Key { get; }

    /// <summary>
    /// Return 0, if the command should not be repeatable via a CommandArgument/Count; otherwise, return null, to indicate that the command allows
    /// the player to specify a CommandArgument/Count; or a value greater than 0, to indicate that the command is repeatable but if the player does not
    /// specify a CommandArgument/Count, default the count to the value being returned.
    /// </summary>
    public virtual int? Repeat => 0;

    public virtual bool IsEnabled => true;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns>Returns true, if the command can/should be repeated; false, if the command succeeded or is futile.</returns>
    public abstract bool Execute();
}
