namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class PotionsItemClass : ItemClass
{
    private PotionsItemClass(Game game) : base(game) { }
    public override string Name => "Potion";

    /// <summary>
    /// Returns the potions flavors repository because potions have flavors that need to be identified.  The Apple Juice, Water and Slime-Mold
    /// potions override this
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<PotionReadableFlavor>();
}