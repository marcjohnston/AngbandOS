namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class MushroomFoodItemFactory : FoodItemFactory, IFlavour
{
    public MushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the mushroom flavours repository because mushrooms have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavourRepository() => SaveGame.SingletonRepository.MushroomFlavours;

    /// <inheritdoc/>
    public Flavour Flavour { get; set; }
}
