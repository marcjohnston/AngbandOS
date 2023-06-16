// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// View the character sheet
/// </summary>
[Serializable]
internal class ViewCharacterStoreCommand : BaseStoreCommand
{
    private ViewCharacterStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'C';

    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        SaveGame.DoCmdViewCharacter();
        storeCommandEvent.RequiresRerendering = true;
    }
}
