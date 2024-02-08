// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Pocos;

internal class TownPoco : IToDefinition<TownDefinition>
{
    public string? Key { get; set; }
    public string? DungeonName { get; set; }

    public int? HousePrice { get; set; }

    public string? Name { get; set; }

    public char? Char { get; set; }

    public string[]? StoreFactoryNames { get; set; }

    public bool CanBeEscortedHere { get; set; } = true;

    public bool AllowStartupTown { get; set; } = true;

    public bool UnusedStoreLotsAreGraveyards { get; set; } = false;

    public TownDefinition? ToDefinition()
    {
        if (Key == null || HousePrice == null || Name == null || Char == null || StoreFactoryNames == null || DungeonName == null)
        {
            return null;
        }

        return new TownDefinition()
        {
            Key = Key,
            DungeonName = DungeonName,
            HousePrice = HousePrice.Value,
            Name = Name,
            Char = Char.Value,
            StoreFactoryNames = StoreFactoryNames,
            CanBeEscortedHere = CanBeEscortedHere,
            AllowStartupTown = AllowStartupTown,
            UnusedStoreLotsAreGraveyards = UnusedStoreLotsAreGraveyards
        };
    }
}
