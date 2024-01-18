// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ConfigurationRepository.StoreOwners;
using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class StoreOwnersRepositoryCollection : KeyedDictionaryRepositoryCollection<string, StoreOwner>
{
    public StoreOwnersRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    protected override string? PersistedEntityName => "StoreOwner";

    protected override string SerializeEntity(StoreOwner storeOwner)
    {
        StoreOwnerDefinition storeOwnerDefinition = new()
        {
            Key = storeOwner.Key,
            MaxCost = storeOwner.MaxCost,
            MinInflate = storeOwner.MinInflate,
            OwnerName = storeOwner.OwnerName,
            OwnerRaceName = storeOwner.OwnerRace?.GetKey
        };
        return JsonSerializer.Serialize<StoreOwnerDefinition>(storeOwnerDefinition);
    }

    public override void Load()
    {
        if (SaveGame.Configuration.StoreOwners == null)
        {
            base.Load();
        }
        else
        {
            foreach (StoreOwnerDefinition storeOwnerDefinition in SaveGame.Configuration.StoreOwners)
            {
                Add(new GenericStoreOwner(SaveGame, storeOwnerDefinition));
            }
        }
    }

    public override void Loaded()
    {
        foreach (StoreOwner storeOwner in this)
        {
            storeOwner.Loaded();
        } 
    }
}
