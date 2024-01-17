// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.ConfigurationRepository.StoreOwners;

[Serializable]
internal class GenericStoreOwner : StoreOwner
{
    private readonly string _key;
    private readonly int _maxCost;
    private readonly int _minInflate;
    private readonly string _ownerName;
    private readonly string? _ownerRaceName;

    private Race? _ownerRace;

    public GenericStoreOwner(SaveGame saveGame, StoreOwnerDefinition storeOwner) : base(saveGame)
    {
        _key = storeOwner.Key;
        _maxCost = storeOwner.MaxCost;
        _minInflate = storeOwner.MinInflate;
        _ownerName = storeOwner.OwnerName;
        _ownerRaceName = storeOwner.OwnerRaceName;
    }

    public override void Loaded()
    {
        if (_ownerRaceName != null)
        {
            _ownerRace = SaveGame.SingletonRepository.Races.Get(_ownerRaceName);
        }
    }

    public override string Key => _key;

    public override int MaxCost => _maxCost;

    public override int MinInflate => _minInflate;

    public override string OwnerName => _ownerName;

    public override Race? OwnerRace => _ownerRace;
}
