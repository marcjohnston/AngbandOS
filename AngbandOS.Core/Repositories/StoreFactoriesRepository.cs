﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class StoreFactoriesRepository : DictionaryRepository<string, StoreFactory>
{
    public StoreFactoriesRepository(SaveGame saveGame) : base(saveGame) { }
    public override void Load()
    {
        if (SaveGame.Configuration.StoreFactories == null)
        {
            base.Load();
        }
        else
        {
            foreach (StoreFactoryDefinition storeFactoryDefinition in SaveGame.Configuration.StoreFactories)
            {
                Add(new GenericStoreFactory(SaveGame, storeFactoryDefinition));
            }
        }
    }
}