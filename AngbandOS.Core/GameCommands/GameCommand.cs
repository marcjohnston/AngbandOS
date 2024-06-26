// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.Commands;

[Serializable]
internal abstract class GameCommand : IGetKey
{
    protected readonly Game Game;
    protected GameCommand(Game game)
    {
        Game = game;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind()
    {
        ExecuteScript = ExecuteScriptName == null ? null : (IRepeatableScript)Game.SingletonRepository.Get<Script>(ExecuteScriptName);
    }

    public abstract char KeyChar { get; }

    /// <summary>
    /// Return 0, if the command should not be repeatable via a CommandArgument/Count; otherwise, return null, to indicate that the command allows
    /// the player to specify a CommandArgument/Count; or a value greater than 0, to indicate that the command is repeatable but if the player does not
    /// specify a CommandArgument/Count, default the count to the value being returned.
    /// </summary>
    public virtual int? Repeat => 0;

    public virtual bool IsEnabled => true;

    /// <summary>
    /// Returns the name of an IRepeatableScript for the game command to execute, or null; if the game command does not do anything.  This property is used to bind the ExecuteScript 
    /// property to a script during the bind phase.  Returns null, by default.
    /// </summary>
    protected virtual string? ExecuteScriptName => null;

    /// <summary>
    /// Returns an IRepeatableScript script for the game command to execute, or null, if the game command does not do anything.  This property is bound from the ExecuteScriptName
    /// property during the bind phase.
    /// </summary>
    public IRepeatableScript? ExecuteScript { get; private set; }

    public string ToJson()
    {
        GameCommandDefinition definition = new()
        {
            Key = Key,
            KeyChar = KeyChar,
            Repeat = Repeat,
            IsEnabled = IsEnabled,
            ExecuteScriptName = ExecuteScriptName
        };
        return JsonSerializer.Serialize(definition);
    }
}
