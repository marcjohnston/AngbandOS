// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class PotionItemFactory : ItemFactory, IFlavorFactory
{
    public PotionItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(PotionsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavor.
    /// </summary>
    public IFlavorFactory FlavorFactory => (IFlavorFactory)this;

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{FlavorFactory.Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{CountPluralize("Potion", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        int cost = item.Value();
        if (cost <= 60)
        {
            return item.MassRoll(3, 5);
        }
        if (cost <= 240)
        {
            return item.MassRoll(1, 5);
        }
        return 0;
    }

    /// <summary>
    /// Returns the potions flavors repository because potions have flavors that need to be identified.  The Apple Juice, Water and Slime-Mold
    /// potions override this
    /// </summary>
    public virtual IEnumerable<Flavor>? GetFlavorRepository() => SaveGame.SingletonRepository.PotionReadableFlavors;

    public override int PercentageBreakageChance => 100;
    public override bool CanBeQuaffed => true;

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }

    public override bool EasyKnow => true;
    public override int PackSort => 11;
    /// <summary>
    /// Have a potion affect the player.  Activates the potion effect.
    /// </summary>
    /// <returns> True, if drinking the potion identified it; false, to keep the potion as unidentified.</returns>
    public abstract bool Quaff();

    /// <summary>
    /// Perform a smash effect for the potion.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="who"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns>Returns whether or not the action causes pets to become angry and turn against their owner.  Returns false, by default.</returns>
    public virtual bool Smash(int who, int y, int x)
    {
        return false;
    }

    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Potion;
    public override int BaseValue => 20;
    public override bool HatesCold => true;
    public override ColorEnum Color => ColorEnum.Blue;

}
