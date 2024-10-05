// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]

internal class GenericStoreCommand : StoreCommand
{
    public GenericStoreCommand(Game game, StoreCommandConfiguration storeCommandDefinition) : base(game)
    {
        Key = storeCommandDefinition.Key;
        KeyChar = storeCommandDefinition.KeyChar;
        Description = storeCommandDefinition.Description;
        ValidStoreFactoryNames = storeCommandDefinition.ValidStoreFactoryNames;
        ExecuteScriptName = storeCommandDefinition.ExecuteScriptName;
    }

    public override string Key { get; }
    public override char KeyChar { get; }
    public override string Description { get; }
    protected override string[]? ValidStoreFactoryNames { get; }
    protected override string ExecuteScriptName { get; }
}
