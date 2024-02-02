// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RodItemFactory : ItemFactory, IFlavour
{
    public RodItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(RodsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)this;

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown() && item.TypeSpecificValue != 0)
        {
            s += $" (charging)";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavourAware)
    {
        string flavour = item.IdentStoreb ? "" : $"{FlavourFactory.Flavor.Name} ";
        string ofName = isFlavourAware ? $" of {FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Rod", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override bool ItemsCanBeMerged(Item a, Item b)
    {
        if (!base.ItemsCanBeMerged(a, b))
        {
            return false;
        }
        if (a.TypeSpecificValue != b.TypeSpecificValue)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the rod flavours repository because rods have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.RodFlavours;
    public override bool IsRechargable => true;
    public override bool CanBeZapped => true;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }

    public abstract bool RequiresAiming { get; }
    public override bool EasyKnow => true;
    public override int PackSort => 13;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
    public abstract void Execute(ZapRodEvent zapRodEvent);
}
