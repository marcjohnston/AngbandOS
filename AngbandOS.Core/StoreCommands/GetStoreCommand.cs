// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class GetStoreCommand : BaseStoreCommand
{
    private GetStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'g';

    public override string Description => "Get an item";

    public override bool IsEnabled(Store store) => (store.GetType() != typeof(HallStore));

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.StorePurchase();
    }
}
