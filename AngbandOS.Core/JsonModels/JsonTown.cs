// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.JsonModels;

internal class JsonTown : IJsonModel<TownDefinition>
{
    public string? Key { get; set; }

    public int? HousePrice { get; set; }

    public string? Name { get; set; }

    public char? Char { get; set; }

    public string[]? StoreFactoryNames { get; set; }

    public bool CanBeEscortedHere { get; set; } = true;

    public bool AllowStartupTown { get; set; } = true;

    public bool UnusedStoreLotsAreGraveyards { get; set; } = false;

    public TownDefinition? ToDefinition()
    {
        if (Key == null || HousePrice == null || Name == null || Char == null || StoreFactoryNames == null)
        {
            return null;
        }

        return new TownDefinition()
        {
            Key = Key,
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

[Serializable]
internal class JsonVault : IJsonModel<VaultDefinition>
{
    public string? Key { get; set; }
    public ColorEnum? Color { get; set; } = ColorEnum.White;
    public string? Name { get; set; }
    public int? Category { get; set; }
    public int? Height { get; set; }
    public int? Rating { get; set; }
    public string? Text { get; set; }
    public int? Width { get; set; }

    public VaultDefinition? ToDefinition()
    {
        if (Key == null || Color == null || Name == null || Category == null || Height == null || Rating == null || Text == null || Width == null)
        {
            return null;
        }

        return new VaultDefinition()
        {
            Key = Key,
            Color = Color.Value,
            Name = Name,
            Category = Category.Value,
            Height = Height.Value,
            Rating = Rating.Value,
            Text = Text,
            Width = Width.Value
        };
    }
}