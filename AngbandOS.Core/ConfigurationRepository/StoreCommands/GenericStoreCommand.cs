// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.StoreCommands;

internal class GenericStoreCommand : StoreCommand
{
    private readonly string _key;
    private readonly char _keyChar;
    private readonly string _description;
    private readonly string[]? _validStoreNames;
    private readonly string _executeScriptName;

    public GenericStoreCommand(SaveGame saveGame, StoreCommandDefinition storeCommandDefinition) : base(saveGame)
    {
        _key = storeCommandDefinition.Key;
        _keyChar = storeCommandDefinition.KeyChar;
        _description = storeCommandDefinition.Description;
        _validStoreNames = storeCommandDefinition.ValidStoreNames;
        _executeScriptName = storeCommandDefinition.ExecuteScriptName;
    }

    public override string Key => _key;
    public override char KeyChar => _keyChar;
    public override string Description => _description;
    protected override string[]? ValidStoreNames => _validStoreNames;
    protected override string ExecuteScriptName => _executeScriptName;
}
