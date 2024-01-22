// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.Commands;

[Serializable]
internal abstract class GameCommand : IGetKey<string>, IToJson
{
    protected SaveGame SaveGame { get; }
    protected GameCommand(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind()
    {
        ExecuteScript = SaveGame.SingletonRepository.Scripts.Get(ExecuteScriptName);
    }

    public abstract char KeyChar { get; }

    /// <summary>
    /// Return 0, if the command should not be repeatable via a CommandArgument/Count; otherwise, return null, to indicate that the command allows
    /// the player to specify a CommandArgument/Count; or a value greater than 0, to indicate that the command is repeatable but if the player does not
    /// specify a CommandArgument/Count, default the count to the value being returned.
    /// </summary>
    public virtual int? Repeat => 0;

    public virtual bool IsEnabled => true;
    protected virtual string ExecuteScriptName { get; }

    public Script ExecuteScript { get; protected set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns>Returns true, if the command can/should be repeated; false, if the command succeeded or is futile.</returns>
    public bool Execute()
    {
        return ExecuteScript.Execute();
    }

    public string ToJson()
    {
        GameCommandDefinition definition = new()
        {
            Key = Key,
            KeyChar = KeyChar,
            Repeat = Repeat,
            IsEnabled = IsEnabled,
            ExecuteScriptName = ExecuteScript.GetKey
        };
        return JsonSerializer.Serialize(definition);
    }
}
