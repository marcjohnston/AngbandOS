// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    [Serializable]
    internal class Town
    {
        public readonly char Char;
        public readonly int HousePrice;
        public readonly string Name;
        public readonly Store[] Stores;
        public int Index;

        /// <summary>
        /// Represents the RND seed that is used to generate the town.  This ensures the town is regenerated the same when the player returns.
        /// </summary>
        public int Seed;
        public bool Visited;
        public int X;
        public int Y;

        private Town(Store[] stores, int housePrice, string name, char character)
        {
            X = 0;
            Y = 0;
            Seed = 0;
            Visited = false;
            Stores = stores;
            HousePrice = housePrice;
            Name = name;
            Char = character;
        }

        public static Town[] NewTownList(SaveGame saveGame) // TODO: Do we need this?
        {
            Town[] array = new[]
            {
                // Celephais
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new ArmouryStore(saveGame),
                        new WeaponStore(saveGame), new TempleStore(saveGame),
                        new TempleStore(saveGame), new AlchemistStore(saveGame),
                        new MagicStore(saveGame), new HomeStore(saveGame),
                        new LibraryStore(saveGame), new InnStore(saveGame),
                        new HallStore(saveGame), new PawnStore(saveGame)
                    }, 50000, "the beautiful city of Celephais", 'C'),
                // Dylath-Leen
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new ArmouryStore(saveGame),
                        new WeaponStore(saveGame), new BlackStore(saveGame),
                        new BlackStore(saveGame), new BlackStore(saveGame),
                        new HomeStore(saveGame), new LibraryStore(saveGame),
                        new EmptyLotStore(saveGame), new InnStore(saveGame),
                        new HallStore(saveGame), new PawnStore(saveGame)
                    }, 25000, "the unwholesome city of Dylath-Leen", 'D'),
                // Hlanith
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new ArmouryStore(saveGame),
                        new EmptyLotStore(saveGame), new WeaponStore(saveGame),
                        new EmptyLotStore(saveGame), new AlchemistStore(saveGame),
                        new MagicStore(saveGame), new BlackStore(saveGame),
                        new HomeStore(saveGame), new LibraryStore(saveGame),
                        new InnStore(saveGame), new HallStore(saveGame)
                    }, 45000, "the market town of Hlanith", 'H'),
                // Inganok
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new ArmouryStore(saveGame),
                        new WeaponStore(saveGame), new TempleStore(saveGame),
                        new AlchemistStore(saveGame), new EmptyLotStore(saveGame),
                        new MagicStore(saveGame), new BlackStore(saveGame),
                        new EmptyLotStore(saveGame), new LibraryStore(saveGame),
                        new InnStore(saveGame), new PawnStore(saveGame)
                    }, 0, "the industrious town of Inganok", 'I'),
                // Kadath
                new Town(
                    new[]
                    {
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame)
                    }, 0, "Kadath, home of the Gods", 'K'),
                // Nir
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new EmptyLotStore(saveGame), new EmptyLotStore(saveGame),
                        new InnStore(saveGame), new PawnStore(saveGame)
                    }, 0, "the hamlet of Nir", 'N'),
                // Ulthar
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new ArmouryStore(saveGame),
                        new WeaponStore(saveGame), new TempleStore(saveGame),
                        new AlchemistStore(saveGame), new MagicStore(saveGame),
                        new EmptyLotStore(saveGame), new HomeStore(saveGame),
                        new LibraryStore(saveGame), new InnStore(saveGame),
                        new HallStore(saveGame), new PawnStore(saveGame)
                    }, 45000, "the picturesque town of Ulthar", 'U'),
                // Ilek-Vad
                new Town(
                    new Store[]
                    {
                        new GeneralStore(saveGame), new ArmouryStore(saveGame),
                        new WeaponStore(saveGame), new TempleStore(saveGame),
                        new AlchemistStore(saveGame), new MagicStore(saveGame),
                        new BlackStore(saveGame), new HomeStore(saveGame),
                        new LibraryStore(saveGame), new EmptyLotStore(saveGame),
                        new InnStore(saveGame), new HallStore(saveGame)
                    }, 60000, "the city of Ilek-Vad", 'V')
            };
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Index = i;
            }
            return array;
        }
    }
}