﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class SellStoreCommand : StoreCommand
{
    private SellStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 's';

    public override string Description => "Sell an item";

    public override bool IsEnabled(Store store) => (store.GetType() != typeof(HallStore));

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.StoreSell();
    }
}