﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class NirTown : Town
{
    private NirTown(SaveGame saveGame) : base(saveGame) { }
    public override Store[] Stores => new Store[]
        {
            SaveGame.SingletonRepository.Stores.Get<GeneralStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<InnStore>(),
            SaveGame.SingletonRepository.Stores.Get<PawnStore>()
        };

    public override int HousePrice => 0;
    public override string Name => "the hamlet of Nir";
    public override char Char => 'N';
}