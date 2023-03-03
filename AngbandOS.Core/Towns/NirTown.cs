// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns
{
    [Serializable]
    internal class NirTown : Town
    {
        private Store[] _stores;
        private NirTown(SaveGame saveGame) : base(saveGame)
        {
            _stores = new Store[]
            {
                new GeneralStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new EmptyLotStore(SaveGame),
                new InnStore(SaveGame),
                new PawnStore(SaveGame)
            };
        }
        public override Store[] Stores => _stores;

        public override int HousePrice => 0;
        public override string Name => "the hamlet of Nir";
        public override char Char => 'N';
    }
}