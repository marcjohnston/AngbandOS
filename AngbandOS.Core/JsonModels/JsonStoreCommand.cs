﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.JsonModels;

internal class JsonStoreCommand : IJsonModel<StoreCommandDefinition>
{
    public string? Key { get; set; }
    public char? KeyChar { get; set; }
    public string? Description { get; set; }
    public string[]? ValidStoreNames { get; set; }
    public string? ExecuteScriptName { get; set; }

    public StoreCommandDefinition? ToDefinition()
    {
        if (Key == null || KeyChar == null || Description == null || ExecuteScriptName == null)
            return null;

        return new StoreCommandDefinition()
        {
            Key = Key,
            KeyChar = KeyChar.Value,
            Description = Description,
            ValidStoreNames = ValidStoreNames,
            ExecuteScriptName = ExecuteScriptName
        };
    }
}