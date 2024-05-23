// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class MushroomFoodItemFactory : FoodItemFactory
{
    public MushroomFoodItemFactory(Game game) : base(game) { }

    public override bool HasFlavor => true;
    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Mushroom", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    /// <summary>
    /// Returns the mushroom flavors repository because mushrooms have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<MushroomReadableFlavor>();

    /// <summary>
    /// Returns a nutritional value of 500 turns for all mushrooms.
    /// </summary>
    public override int InitialNutritionalValue => 500;
}
