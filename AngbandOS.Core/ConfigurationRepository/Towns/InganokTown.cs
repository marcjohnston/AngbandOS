// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class InganokTown : Town
{
    private InganokTown(SaveGame saveGame) : base(saveGame) { }
    protected override string[] StoreFactoryNames => new string[] {
        nameof(GeneralStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(WeaponStoreFactory),
        nameof(TempleStoreFactory),
        nameof(AlchemistStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(MagicStoreFactory),
        nameof(BlackStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(InnStoreFactory),
        nameof(PawnStoreFactory)
    };

    public override int HousePrice => 0;
    public override string Name => "the industrious town of Inganok";
    public override char Char => 'I';
}