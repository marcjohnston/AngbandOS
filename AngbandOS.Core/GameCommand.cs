// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal class GameCommand : IGetKey
{
    protected readonly Game Game;
    public GameCommand(Game game, GameCommandGameConfiguration gameCommandGameConfiguration)
    {
        Game = game;
        Key = gameCommandGameConfiguration.Key ?? gameCommandGameConfiguration.GetType().Name;
        KeyChar = gameCommandGameConfiguration.KeyChar;
        IsEnabled = gameCommandGameConfiguration.IsEnabled;
        Repeat = gameCommandGameConfiguration.Repeat;
        ExecuteScriptName = gameCommandGameConfiguration.ExecuteScriptName;
    }

    public virtual string Key { get; } 

    public string GetKey => Key;
    public void Bind()
    {
        ExecuteScript = ExecuteScriptName == null ? null : Game.SingletonRepository.Get<IGameCommandScript>(ExecuteScriptName);
    }

    public virtual char KeyChar { get; }

    /// <summary>
    /// Return 0, if the command should not be repeatable via a CommandArgument/Count; otherwise, return null, to indicate that the command allows
    /// the player to specify a CommandArgument/Count; or a value greater than 0, to indicate that the command is repeatable but if the player does not
    /// specify a CommandArgument/Count, default the count to the value being returned.
    /// </summary>
    public virtual int? Repeat { get; } = 0;

    public virtual bool IsEnabled { get; } = true;

    /// <summary>
    /// Returns the name of an IRepeatableScript for the game command to execute, or null; if the game command does not do anything.  This property is used to bind the ExecuteScript 
    /// property to a script during the bind phase.  Returns null, by default.
    /// </summary>
    protected virtual string? ExecuteScriptName { get; } = null;

    /// <summary>
    /// Returns an IRepeatableScript script for the game command to execute, or null, if the game command does not do anything.  This property is bound from the ExecuteScriptName
    /// property during the bind phase.
    /// </summary>
    public IGameCommandScript? ExecuteScript { get; private set; }

    public string ToJson()
    {
        GameCommandGameConfiguration definition = new()
        {
            Key = Key,
            KeyChar = KeyChar,
            Repeat = Repeat,
            IsEnabled = IsEnabled,
            ExecuteScriptName = ExecuteScriptName
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}
