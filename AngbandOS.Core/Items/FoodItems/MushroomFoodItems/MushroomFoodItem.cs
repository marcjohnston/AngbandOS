namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class MushroomFoodItem : FoodItem
{
    public MushroomFoodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)Factory;

    public override string GetDescription(bool includeCountPrefix)
    {
        string flavour = IdentStoreb ? "" : $"{FlavourFactory.Flavour.Name} ";
        string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Mushroom", Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
    }
}