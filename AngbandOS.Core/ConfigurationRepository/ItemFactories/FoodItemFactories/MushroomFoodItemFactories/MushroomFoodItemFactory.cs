// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class MushroomFoodItemFactory : FoodItemFactory, IFlavour
{
    public MushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)this;

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavourAware)
    {
        string flavour = item.IdentStoreb ? "" : $"{FlavourFactory.Flavor.Name} ";
        string ofName = isFlavourAware ? $" of {FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Mushroom", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    /// <summary>
    /// Returns the mushroom flavours repository because mushrooms have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.MushroomFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }
}
