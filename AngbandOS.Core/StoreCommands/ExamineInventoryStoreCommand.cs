// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Examine an item from the player's inventory
/// </summary>
[Serializable]
internal class ExamineInventoryStoreCommand : StoreCommand
{
    private ExamineInventoryStoreCommand(Game game) : base(game) { }
    public override char KeyChar => 'I';

    public override string Description => "";

    protected override string ExecuteScriptName => nameof(ExamineScript);
}
