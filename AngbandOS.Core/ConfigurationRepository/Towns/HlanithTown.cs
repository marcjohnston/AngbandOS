// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class HlanithTown : Town
{
    private HlanithTown(SaveGame saveGame) : base(saveGame) { }
    public override Store[] Stores => new Store[]
        {
            SaveGame.SingletonRepository.Stores.Get(nameof(GeneralStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(ArmouryStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(EmptyLotStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(WeaponStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(EmptyLotStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(AlchemistStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(MagicStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(BlackStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(HomeStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(LibraryStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(InnStore)),
            SaveGame.SingletonRepository.Stores.Get(nameof(HallStore))
        };

    public override int HousePrice => 45000;
    public override string Name => "the market town of Hlanith";
    public override char Char => 'H';
}