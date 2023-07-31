// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class IlekVadTown : Town
{
    private IlekVadTown(SaveGame saveGame) : base(saveGame) { }

    public override Store[] Stores => new Store[]
        {
            SaveGame.SingletonRepository.Stores.Get<GeneralStore>(),
            SaveGame.SingletonRepository.Stores.Get<ArmouryStore>(),
            SaveGame.SingletonRepository.Stores.Get<WeaponStore>(),
            SaveGame.SingletonRepository.Stores.Get<TempleStore>(),
            SaveGame.SingletonRepository.Stores.Get<AlchemistStore>(),
            SaveGame.SingletonRepository.Stores.Get<MagicStore>(),
            SaveGame.SingletonRepository.Stores.Get<BlackStore>(),
            SaveGame.SingletonRepository.Stores.Get<HomeStore>(),
            SaveGame.SingletonRepository.Stores.Get<LibraryStore>(),
            SaveGame.SingletonRepository.Stores.Get<EmptyLotStore>(),
            SaveGame.SingletonRepository.Stores.Get<InnStore>(),
            SaveGame.SingletonRepository.Stores.Get<HallStore>()
        };

    public override int HousePrice => 60000;
    public override string Name => "the city of Ilek-Vad";
    public override char Char => 'V';
}