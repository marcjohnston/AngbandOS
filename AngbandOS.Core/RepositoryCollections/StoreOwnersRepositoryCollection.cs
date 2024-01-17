// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class StoreOwnersRepositoryCollection : DictionaryRepositoryCollection<StoreOwner>
{
    public StoreOwnersRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    protected override string? PersistedEntityName => "StoreOwner";

    protected override string? SerializeEntity(StoreOwner storeOwner)
    {
        ModelStoreOwner modelStoreOwner = new()
        {
            MaxCost = storeOwner.MaxCost,
            MinInflate = storeOwner.MinInflate,
            OwnerName = storeOwner.OwnerName,
            OwnerRaceName = storeOwner.OwnerRace?.Title
        };
        return JsonSerializer.Serialize<ModelStoreOwner>(modelStoreOwner);
    }
}

internal class ModelStoreOwner
{
    public int? MaxCost { get; set; }

    public int? MinInflate { get; set; }

    public string? OwnerName { get; set; }

    public string? OwnerRaceName { get; set; }
}

internal class DbStoreOwner : StoreOwner
{
    private int _maxCost { get; set; }

    private int _minInflate { get; set; }

    private string _ownerName { get; set; }

    private Race? _ownerRace { get; set; }

    public DbStoreOwner(SaveGame saveGame, string json) : base(saveGame)
    {
        ModelStoreOwner? modelStoreOwner = JsonSerializer.Deserialize<ModelStoreOwner>(json);
        if (modelStoreOwner == null || modelStoreOwner.MaxCost == null || modelStoreOwner.MinInflate == null || modelStoreOwner.OwnerName == null)
            throw new Exception("Invalid store owner json.");
        _maxCost = modelStoreOwner.MaxCost.Value;
        _minInflate = modelStoreOwner.MinInflate.Value;
        _ownerName = modelStoreOwner.OwnerName;
        if (modelStoreOwner.OwnerRaceName != null)
        {
            _ownerRace = SaveGame.SingletonRepository.Races.Get(modelStoreOwner.OwnerRaceName);
        }
    }

    public override int MaxCost => _maxCost;

    public override int MinInflate => _minInflate;

    public override string OwnerName => _ownerName;

    public override Race? OwnerRace => _ownerRace;
}
