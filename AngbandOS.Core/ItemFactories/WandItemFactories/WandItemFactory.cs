// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class WandItemFactory : ItemFactory, IFlavorFactory
{
    public WandItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.ItemClasses.Get(nameof(WandsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavor.
    /// </summary>
    public IFlavorFactory FlavorFactory => (IFlavorFactory)this;

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            s += $" ({item.TypeSpecificValue} {Game.CountPluralize("charge", item.TypeSpecificValue)})";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }
    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{FlavorFactory.Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Wand", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        return value / 20 * item.TypeSpecificValue;
    }

    /// <summary>
    /// Returns the want flavors repository because wands have flavors that need to be identified.
    /// </summary>
    public IEnumerable<Flavor>? GetFlavorRepository() => Game.SingletonRepository.Get<WandReadableFlavor>();

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }
    public override int PercentageBreakageChance => 25;
    public override bool IsRechargable => true;

    public override int PackSort => 14;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
    public abstract bool ExecuteActivation(Game game, int dir);
    public override int BaseValue => 50;
    public override bool CanBeAimed => true;
    public override bool HatesElectricity => true;

    //public override bool IsCharged => true;
    public override ColorEnum Color => ColorEnum.Chartreuse;
}
