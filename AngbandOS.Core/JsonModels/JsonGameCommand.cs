// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.JsonModels;

[Serializable]
internal class JsonGameCommand : IJsonModel<GameCommandDefinition>
{
    public string? Key { get; set; }
    public char? KeyChar { get; set; }
    public int? Repeat { get; set; } = 0;
    public bool? IsEnabled { get; set; } = true;
    public string? ScriptName { get; set; }

    public GameCommandDefinition? ToDefinition()
    {
        if (Key == null || KeyChar == null || IsEnabled == null || ScriptName == null)
            return null;

        return new GameCommandDefinition()
        {
            Key = Key,
            KeyChar = KeyChar.Value,
            Repeat = Repeat,
            IsEnabled = IsEnabled.Value,
            ScriptName = ScriptName
        };
    }
}